using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.SSRS2010;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Jobs.SSRS
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.SSRS.ReportingService" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.SSRS"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ReportingServiceTest : AbstractBaseSetupTypedTest<ReportingService>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingService) Initializer

        private const string MethodGetInstance = "GetInstance";
        private const string MethodCreateSiteCollectionMappedFolder = "CreateSiteCollectionMappedFolder";
        private const string MethodDeleteSiteCollectionMappedFolder = "DeleteSiteCollectionMappedFolder";
        private const string MethodSyncReports = "SyncReports";
        private const string MethodDeleteReport = "DeleteReport";
        private const string MethodAddRoleMapping = "AddRoleMapping";
        private const string MethodRemoveRoleMapping = "RemoveRoleMapping";
        private const string MethodListSubscriptions = "ListSubscriptions";
        private const string MethodListExtensions = "ListExtensions";
        private const string MethodGetItemParameters = "GetItemParameters";
        private const string MethodEnableSubscription = "EnableSubscription";
        private const string MethodDisableSubscription = "DisableSubscription";
        private const string MethodDeleteSubscription = "DeleteSubscription";
        private const string MethodListChildren = "ListChildren";
        private const string MethodCreateSubscription = "CreateSubscription";
        private const string MethodChangeSubscriptionOwner = "ChangeSubscriptionOwner";
        private const string MethodGetSubscriptionProperties = "GetSubscriptionProperties";
        private const string MethodSetSubscriptionProperties = "SetSubscriptionProperties";
        private const string MethodGetSSRSRole = "GetSSRSRole";
        private const string MethodAssignSsrsRole = "AssignSsrsRole";
        private const string MethodUploadReport = "UploadReport";
        private const string MethodCreateFoldersIfNotExist = "CreateFoldersIfNotExist";
        private const string Field_locks = "_locks";
        private const string FieldsiteCollectionId = "siteCollectionId";
        private const string Fieldclient = "client";
        private const string FielddataSources = "dataSources";
        private Type _reportingServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingService _reportingServiceInstance;
        private ReportingService _reportingServiceInstanceFixture;

        #region General Initializer : Class (ReportingService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingServiceInstanceType = typeof(ReportingService);
            _reportingServiceInstanceFixture = Create(true);
            _reportingServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingService)

        #region General Initializer : Class (ReportingService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetInstance, 0)]
        [TestCase(MethodCreateSiteCollectionMappedFolder, 0)]
        [TestCase(MethodDeleteSiteCollectionMappedFolder, 0)]
        [TestCase(MethodSyncReports, 0)]
        [TestCase(MethodDeleteReport, 0)]
        [TestCase(MethodAddRoleMapping, 0)]
        [TestCase(MethodRemoveRoleMapping, 0)]
        [TestCase(MethodListSubscriptions, 0)]
        [TestCase(MethodListExtensions, 0)]
        [TestCase(MethodGetItemParameters, 0)]
        [TestCase(MethodEnableSubscription, 0)]
        [TestCase(MethodDisableSubscription, 0)]
        [TestCase(MethodDeleteSubscription, 0)]
        [TestCase(MethodListChildren, 0)]
        [TestCase(MethodCreateSubscription, 0)]
        [TestCase(MethodChangeSubscriptionOwner, 0)]
        [TestCase(MethodGetSubscriptionProperties, 0)]
        [TestCase(MethodSetSubscriptionProperties, 0)]
        [TestCase(MethodGetSSRSRole, 0)]
        [TestCase(MethodAssignSsrsRole, 0)]
        [TestCase(MethodUploadReport, 0)]
        [TestCase(MethodCreateFoldersIfNotExist, 0)]
        public void AUT_ReportingService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingServiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingService) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_locks)]
        [TestCase(FieldsiteCollectionId)]
        [TestCase(Fieldclient)]
        [TestCase(FielddataSources)]
        public void AUT_ReportingService_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportingServiceInstanceFixture, 
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
        ///     Class (<see cref="ReportingService" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetInstance)]
        public void AUT_ReportingService_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportingServiceInstanceFixture,
                                                                              _reportingServiceInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateSiteCollectionMappedFolder)]
        [TestCase(MethodDeleteSiteCollectionMappedFolder)]
        [TestCase(MethodSyncReports)]
        [TestCase(MethodDeleteReport)]
        [TestCase(MethodAddRoleMapping)]
        [TestCase(MethodRemoveRoleMapping)]
        [TestCase(MethodListSubscriptions)]
        [TestCase(MethodListExtensions)]
        [TestCase(MethodGetItemParameters)]
        [TestCase(MethodEnableSubscription)]
        [TestCase(MethodDisableSubscription)]
        [TestCase(MethodDeleteSubscription)]
        [TestCase(MethodListChildren)]
        [TestCase(MethodCreateSubscription)]
        [TestCase(MethodChangeSubscriptionOwner)]
        [TestCase(MethodGetSubscriptionProperties)]
        [TestCase(MethodSetSubscriptionProperties)]
        [TestCase(MethodGetSSRSRole)]
        [TestCase(MethodAssignSsrsRole)]
        [TestCase(MethodUploadReport)]
        [TestCase(MethodCreateFoldersIfNotExist)]
        public void AUT_ReportingService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetInstance) (Return Type : IReportingService) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_GetInstance_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetInstancePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingServiceInstanceFixture, _reportingServiceInstanceType, MethodGetInstance, Fixture, methodGetInstancePrametersTypes);
        }

        #endregion

        #region Method Call : (GetInstance) (Return Type : IReportingService) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetInstance_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportingService.GetInstance(site);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetInstance) (Return Type : IReportingService) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetInstance_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodGetInstancePrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfGetInstance = { site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetInstance, methodGetInstancePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingServiceInstanceFixture, _reportingServiceInstanceType, MethodGetInstance, Fixture, methodGetInstancePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IReportingService>(_reportingServiceInstanceFixture, _reportingServiceInstanceType, MethodGetInstance, parametersOfGetInstance, methodGetInstancePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfGetInstance);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetInstance.ShouldNotBeNull();
            parametersOfGetInstance.Length.ShouldBe(1);
            methodGetInstancePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetInstance) (Return Type : IReportingService) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetInstance_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodGetInstancePrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfGetInstance = { site };

            // Assert
            parametersOfGetInstance.ShouldNotBeNull();
            parametersOfGetInstance.Length.ShouldBe(1);
            methodGetInstancePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IReportingService>(_reportingServiceInstanceFixture, _reportingServiceInstanceType, MethodGetInstance, parametersOfGetInstance, methodGetInstancePrametersTypes));
        }

        #endregion

        #region Method Call : (GetInstance) (Return Type : IReportingService) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetInstance_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetInstancePrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingServiceInstanceFixture, _reportingServiceInstanceType, MethodGetInstance, Fixture, methodGetInstancePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetInstancePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetInstance) (Return Type : IReportingService) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetInstance_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetInstancePrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingServiceInstanceFixture, _reportingServiceInstanceType, MethodGetInstance, Fixture, methodGetInstancePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetInstancePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInstance) (Return Type : IReportingService) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetInstance_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInstance, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetInstance) (Return Type : IReportingService) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetInstance_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetInstance, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateSiteCollectionMappedFolder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_CreateSiteCollectionMappedFolder_Method_Call_Internally(Type[] types)
        {
            var methodCreateSiteCollectionMappedFolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodCreateSiteCollectionMappedFolder, Fixture, methodCreateSiteCollectionMappedFolderPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateSiteCollectionMappedFolder) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSiteCollectionMappedFolder_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.CreateSiteCollectionMappedFolder();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateSiteCollectionMappedFolder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSiteCollectionMappedFolder_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateSiteCollectionMappedFolderPrametersTypes = null;
            object[] parametersOfCreateSiteCollectionMappedFolder = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateSiteCollectionMappedFolder, methodCreateSiteCollectionMappedFolderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfCreateSiteCollectionMappedFolder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateSiteCollectionMappedFolder.ShouldBeNull();
            methodCreateSiteCollectionMappedFolderPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateSiteCollectionMappedFolder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSiteCollectionMappedFolder_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateSiteCollectionMappedFolderPrametersTypes = null;
            object[] parametersOfCreateSiteCollectionMappedFolder = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodCreateSiteCollectionMappedFolder, parametersOfCreateSiteCollectionMappedFolder, methodCreateSiteCollectionMappedFolderPrametersTypes);

            // Assert
            parametersOfCreateSiteCollectionMappedFolder.ShouldBeNull();
            methodCreateSiteCollectionMappedFolderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateSiteCollectionMappedFolder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSiteCollectionMappedFolder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateSiteCollectionMappedFolderPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodCreateSiteCollectionMappedFolder, Fixture, methodCreateSiteCollectionMappedFolderPrametersTypes);

            // Assert
            methodCreateSiteCollectionMappedFolderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateSiteCollectionMappedFolder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSiteCollectionMappedFolder_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateSiteCollectionMappedFolder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSiteCollectionMappedFolder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_DeleteSiteCollectionMappedFolder_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSiteCollectionMappedFolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodDeleteSiteCollectionMappedFolder, Fixture, methodDeleteSiteCollectionMappedFolderPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSiteCollectionMappedFolder) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSiteCollectionMappedFolder_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.DeleteSiteCollectionMappedFolder();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteSiteCollectionMappedFolder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSiteCollectionMappedFolder_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDeleteSiteCollectionMappedFolderPrametersTypes = null;
            object[] parametersOfDeleteSiteCollectionMappedFolder = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteSiteCollectionMappedFolder, methodDeleteSiteCollectionMappedFolderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfDeleteSiteCollectionMappedFolder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteSiteCollectionMappedFolder.ShouldBeNull();
            methodDeleteSiteCollectionMappedFolderPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSiteCollectionMappedFolder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSiteCollectionMappedFolder_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDeleteSiteCollectionMappedFolderPrametersTypes = null;
            object[] parametersOfDeleteSiteCollectionMappedFolder = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodDeleteSiteCollectionMappedFolder, parametersOfDeleteSiteCollectionMappedFolder, methodDeleteSiteCollectionMappedFolderPrametersTypes);

            // Assert
            parametersOfDeleteSiteCollectionMappedFolder.ShouldBeNull();
            methodDeleteSiteCollectionMappedFolderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSiteCollectionMappedFolder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSiteCollectionMappedFolder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDeleteSiteCollectionMappedFolderPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodDeleteSiteCollectionMappedFolder, Fixture, methodDeleteSiteCollectionMappedFolderPrametersTypes);

            // Assert
            methodDeleteSiteCollectionMappedFolderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSiteCollectionMappedFolder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSiteCollectionMappedFolder_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteSiteCollectionMappedFolder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncReports) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_SyncReports_Method_Call_Internally(Type[] types)
        {
            var methodSyncReportsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodSyncReports, Fixture, methodSyncReportsPrametersTypes);
        }

        #endregion

        #region Method Call : (SyncReports) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SyncReports_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var reportLibrary = CreateType<SPDocumentLibrary>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.SyncReports(reportLibrary);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SyncReports) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SyncReports_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var reportLibrary = CreateType<SPDocumentLibrary>();
            var methodSyncReportsPrametersTypes = new Type[] { typeof(SPDocumentLibrary) };
            object[] parametersOfSyncReports = { reportLibrary };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSyncReports, methodSyncReportsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfSyncReports);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSyncReports.ShouldNotBeNull();
            parametersOfSyncReports.Length.ShouldBe(1);
            methodSyncReportsPrametersTypes.Length.ShouldBe(1);
            methodSyncReportsPrametersTypes.Length.ShouldBe(parametersOfSyncReports.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SyncReports) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SyncReports_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reportLibrary = CreateType<SPDocumentLibrary>();
            var methodSyncReportsPrametersTypes = new Type[] { typeof(SPDocumentLibrary) };
            object[] parametersOfSyncReports = { reportLibrary };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodSyncReports, parametersOfSyncReports, methodSyncReportsPrametersTypes);

            // Assert
            parametersOfSyncReports.ShouldNotBeNull();
            parametersOfSyncReports.Length.ShouldBe(1);
            methodSyncReportsPrametersTypes.Length.ShouldBe(1);
            methodSyncReportsPrametersTypes.Length.ShouldBe(parametersOfSyncReports.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncReports) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SyncReports_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSyncReports, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SyncReports) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SyncReports_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSyncReportsPrametersTypes = new Type[] { typeof(SPDocumentLibrary) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodSyncReports, Fixture, methodSyncReportsPrametersTypes);

            // Assert
            methodSyncReportsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncReports) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SyncReports_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSyncReports, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteReport) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_DeleteReport_Method_Call_Internally(Type[] types)
        {
            var methodDeleteReportPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodDeleteReport, Fixture, methodDeleteReportPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteReport) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteReport_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.DeleteReport(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteReport) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteReport_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteReportPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteReport = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteReport, methodDeleteReportPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfDeleteReport);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteReport.ShouldNotBeNull();
            parametersOfDeleteReport.Length.ShouldBe(1);
            methodDeleteReportPrametersTypes.Length.ShouldBe(1);
            methodDeleteReportPrametersTypes.Length.ShouldBe(parametersOfDeleteReport.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteReport) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteReport_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteReportPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteReport = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodDeleteReport, parametersOfDeleteReport, methodDeleteReportPrametersTypes);

            // Assert
            parametersOfDeleteReport.ShouldNotBeNull();
            parametersOfDeleteReport.Length.ShouldBe(1);
            methodDeleteReportPrametersTypes.Length.ShouldBe(1);
            methodDeleteReportPrametersTypes.Length.ShouldBe(parametersOfDeleteReport.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteReport) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteReport_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteReport, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteReport) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteReport_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteReportPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodDeleteReport, Fixture, methodDeleteReportPrametersTypes);

            // Assert
            methodDeleteReportPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteReport) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteReport_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteReport, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRoleMapping) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_AddRoleMapping_Method_Call_Internally(Type[] types)
        {
            var methodAddRoleMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodAddRoleMapping, Fixture, methodAddRoleMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (AddRoleMapping) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AddRoleMapping_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var groups = CreateType<SPGroupCollection>();
            var userList = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.AddRoleMapping(groups, userList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddRoleMapping) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AddRoleMapping_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var groups = CreateType<SPGroupCollection>();
            var userList = CreateType<SPList>();
            var methodAddRoleMappingPrametersTypes = new Type[] { typeof(SPGroupCollection), typeof(SPList) };
            object[] parametersOfAddRoleMapping = { groups, userList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddRoleMapping, methodAddRoleMappingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfAddRoleMapping);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddRoleMapping.ShouldNotBeNull();
            parametersOfAddRoleMapping.Length.ShouldBe(2);
            methodAddRoleMappingPrametersTypes.Length.ShouldBe(2);
            methodAddRoleMappingPrametersTypes.Length.ShouldBe(parametersOfAddRoleMapping.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddRoleMapping) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AddRoleMapping_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groups = CreateType<SPGroupCollection>();
            var userList = CreateType<SPList>();
            var methodAddRoleMappingPrametersTypes = new Type[] { typeof(SPGroupCollection), typeof(SPList) };
            object[] parametersOfAddRoleMapping = { groups, userList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodAddRoleMapping, parametersOfAddRoleMapping, methodAddRoleMappingPrametersTypes);

            // Assert
            parametersOfAddRoleMapping.ShouldNotBeNull();
            parametersOfAddRoleMapping.Length.ShouldBe(2);
            methodAddRoleMappingPrametersTypes.Length.ShouldBe(2);
            methodAddRoleMappingPrametersTypes.Length.ShouldBe(parametersOfAddRoleMapping.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRoleMapping) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AddRoleMapping_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddRoleMapping, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddRoleMapping) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AddRoleMapping_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddRoleMappingPrametersTypes = new Type[] { typeof(SPGroupCollection), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodAddRoleMapping, Fixture, methodAddRoleMappingPrametersTypes);

            // Assert
            methodAddRoleMappingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRoleMapping) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AddRoleMapping_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddRoleMapping, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveRoleMapping) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_RemoveRoleMapping_Method_Call_Internally(Type[] types)
        {
            var methodRemoveRoleMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodRemoveRoleMapping, Fixture, methodRemoveRoleMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveRoleMapping) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_RemoveRoleMapping_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.RemoveRoleMapping(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveRoleMapping) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_RemoveRoleMapping_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRemoveRoleMappingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveRoleMapping = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveRoleMapping, methodRemoveRoleMappingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfRemoveRoleMapping);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveRoleMapping.ShouldNotBeNull();
            parametersOfRemoveRoleMapping.Length.ShouldBe(1);
            methodRemoveRoleMappingPrametersTypes.Length.ShouldBe(1);
            methodRemoveRoleMappingPrametersTypes.Length.ShouldBe(parametersOfRemoveRoleMapping.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveRoleMapping) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_RemoveRoleMapping_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRemoveRoleMappingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveRoleMapping = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodRemoveRoleMapping, parametersOfRemoveRoleMapping, methodRemoveRoleMappingPrametersTypes);

            // Assert
            parametersOfRemoveRoleMapping.ShouldNotBeNull();
            parametersOfRemoveRoleMapping.Length.ShouldBe(1);
            methodRemoveRoleMappingPrametersTypes.Length.ShouldBe(1);
            methodRemoveRoleMappingPrametersTypes.Length.ShouldBe(parametersOfRemoveRoleMapping.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveRoleMapping) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_RemoveRoleMapping_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveRoleMapping, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveRoleMapping) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_RemoveRoleMapping_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveRoleMappingPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodRemoveRoleMapping, Fixture, methodRemoveRoleMappingPrametersTypes);

            // Assert
            methodRemoveRoleMappingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveRoleMapping) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_RemoveRoleMapping_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveRoleMapping, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListSubscriptions) (Return Type : Subscription[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_ListSubscriptions_Method_Call_Internally(Type[] types)
        {
            var methodListSubscriptionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListSubscriptions, Fixture, methodListSubscriptionsPrametersTypes);
        }

        #endregion

        #region Method Call : (ListSubscriptions) (Return Type : Subscription[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListSubscriptions_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var itemPathOrSiteURL = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.ListSubscriptions(itemPathOrSiteURL);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ListSubscriptions) (Return Type : Subscription[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListSubscriptions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var itemPathOrSiteURL = CreateType<string>();
            var methodListSubscriptionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfListSubscriptions = { itemPathOrSiteURL };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListSubscriptions, methodListSubscriptionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingService, Subscription[]>(_reportingServiceInstanceFixture, out exception1, parametersOfListSubscriptions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingService, Subscription[]>(_reportingServiceInstance, MethodListSubscriptions, parametersOfListSubscriptions, methodListSubscriptionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfListSubscriptions.ShouldNotBeNull();
            parametersOfListSubscriptions.Length.ShouldBe(1);
            methodListSubscriptionsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfListSubscriptions));
        }

        #endregion

        #region Method Call : (ListSubscriptions) (Return Type : Subscription[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListSubscriptions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var itemPathOrSiteURL = CreateType<string>();
            var methodListSubscriptionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfListSubscriptions = { itemPathOrSiteURL };

            // Assert
            parametersOfListSubscriptions.ShouldNotBeNull();
            parametersOfListSubscriptions.Length.ShouldBe(1);
            methodListSubscriptionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService, Subscription[]>(_reportingServiceInstance, MethodListSubscriptions, parametersOfListSubscriptions, methodListSubscriptionsPrametersTypes));
        }

        #endregion

        #region Method Call : (ListSubscriptions) (Return Type : Subscription[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListSubscriptions_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodListSubscriptionsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListSubscriptions, Fixture, methodListSubscriptionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodListSubscriptionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ListSubscriptions) (Return Type : Subscription[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListSubscriptions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListSubscriptionsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListSubscriptions, Fixture, methodListSubscriptionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodListSubscriptionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListSubscriptions) (Return Type : Subscription[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListSubscriptions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListSubscriptions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListSubscriptions) (Return Type : Subscription[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListSubscriptions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListSubscriptions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListExtensions) (Return Type : Extension[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_ListExtensions_Method_Call_Internally(Type[] types)
        {
            var methodListExtensionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListExtensions, Fixture, methodListExtensionsPrametersTypes);
        }

        #endregion

        #region Method Call : (ListExtensions) (Return Type : Extension[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListExtensions_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var extensionType = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.ListExtensions(extensionType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ListExtensions) (Return Type : Extension[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListExtensions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var extensionType = CreateType<string>();
            var methodListExtensionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfListExtensions = { extensionType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListExtensions, methodListExtensionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingService, Extension[]>(_reportingServiceInstanceFixture, out exception1, parametersOfListExtensions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingService, Extension[]>(_reportingServiceInstance, MethodListExtensions, parametersOfListExtensions, methodListExtensionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfListExtensions.ShouldNotBeNull();
            parametersOfListExtensions.Length.ShouldBe(1);
            methodListExtensionsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfListExtensions));
        }

        #endregion

        #region Method Call : (ListExtensions) (Return Type : Extension[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListExtensions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var extensionType = CreateType<string>();
            var methodListExtensionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfListExtensions = { extensionType };

            // Assert
            parametersOfListExtensions.ShouldNotBeNull();
            parametersOfListExtensions.Length.ShouldBe(1);
            methodListExtensionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService, Extension[]>(_reportingServiceInstance, MethodListExtensions, parametersOfListExtensions, methodListExtensionsPrametersTypes));
        }

        #endregion

        #region Method Call : (ListExtensions) (Return Type : Extension[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListExtensions_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodListExtensionsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListExtensions, Fixture, methodListExtensionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodListExtensionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ListExtensions) (Return Type : Extension[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListExtensions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListExtensionsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListExtensions, Fixture, methodListExtensionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodListExtensionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListExtensions) (Return Type : Extension[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListExtensions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListExtensions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListExtensions) (Return Type : Extension[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListExtensions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListExtensions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemParameters) (Return Type : ItemParameter[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_GetItemParameters_Method_Call_Internally(Type[] types)
        {
            var methodGetItemParametersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetItemParameters, Fixture, methodGetItemParametersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemParameters) (Return Type : ItemParameter[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetItemParameters_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var reportPath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.GetItemParameters(reportPath);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetItemParameters) (Return Type : ItemParameter[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetItemParameters_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var reportPath = CreateType<string>();
            var methodGetItemParametersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetItemParameters = { reportPath };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetItemParameters, methodGetItemParametersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingService, ItemParameter[]>(_reportingServiceInstanceFixture, out exception1, parametersOfGetItemParameters);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingService, ItemParameter[]>(_reportingServiceInstance, MethodGetItemParameters, parametersOfGetItemParameters, methodGetItemParametersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetItemParameters.ShouldNotBeNull();
            parametersOfGetItemParameters.Length.ShouldBe(1);
            methodGetItemParametersPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfGetItemParameters));
        }

        #endregion

        #region Method Call : (GetItemParameters) (Return Type : ItemParameter[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetItemParameters_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reportPath = CreateType<string>();
            var methodGetItemParametersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetItemParameters = { reportPath };

            // Assert
            parametersOfGetItemParameters.ShouldNotBeNull();
            parametersOfGetItemParameters.Length.ShouldBe(1);
            methodGetItemParametersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService, ItemParameter[]>(_reportingServiceInstance, MethodGetItemParameters, parametersOfGetItemParameters, methodGetItemParametersPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItemParameters) (Return Type : ItemParameter[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetItemParameters_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemParametersPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetItemParameters, Fixture, methodGetItemParametersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemParametersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetItemParameters) (Return Type : ItemParameter[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetItemParameters_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemParametersPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetItemParameters, Fixture, methodGetItemParametersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemParametersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemParameters) (Return Type : ItemParameter[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetItemParameters_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemParameters, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItemParameters) (Return Type : ItemParameter[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetItemParameters_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemParameters, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableSubscription) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_EnableSubscription_Method_Call_Internally(Type[] types)
        {
            var methodEnableSubscriptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodEnableSubscription, Fixture, methodEnableSubscriptionPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableSubscription) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_EnableSubscription_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.EnableSubscription(subscriptionID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EnableSubscription) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_EnableSubscription_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var methodEnableSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEnableSubscription = { subscriptionID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableSubscription, methodEnableSubscriptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfEnableSubscription);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableSubscription.ShouldNotBeNull();
            parametersOfEnableSubscription.Length.ShouldBe(1);
            methodEnableSubscriptionPrametersTypes.Length.ShouldBe(1);
            methodEnableSubscriptionPrametersTypes.Length.ShouldBe(parametersOfEnableSubscription.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnableSubscription) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_EnableSubscription_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var methodEnableSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEnableSubscription = { subscriptionID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodEnableSubscription, parametersOfEnableSubscription, methodEnableSubscriptionPrametersTypes);

            // Assert
            parametersOfEnableSubscription.ShouldNotBeNull();
            parametersOfEnableSubscription.Length.ShouldBe(1);
            methodEnableSubscriptionPrametersTypes.Length.ShouldBe(1);
            methodEnableSubscriptionPrametersTypes.Length.ShouldBe(parametersOfEnableSubscription.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableSubscription) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_EnableSubscription_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableSubscription, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableSubscription) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_EnableSubscription_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableSubscriptionPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodEnableSubscription, Fixture, methodEnableSubscriptionPrametersTypes);

            // Assert
            methodEnableSubscriptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableSubscription) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_EnableSubscription_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableSubscription, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableSubscription) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_DisableSubscription_Method_Call_Internally(Type[] types)
        {
            var methodDisableSubscriptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodDisableSubscription, Fixture, methodDisableSubscriptionPrametersTypes);
        }

        #endregion

        #region Method Call : (DisableSubscription) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DisableSubscription_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.DisableSubscription(subscriptionID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DisableSubscription) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DisableSubscription_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var methodDisableSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableSubscription = { subscriptionID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisableSubscription, methodDisableSubscriptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfDisableSubscription);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisableSubscription.ShouldNotBeNull();
            parametersOfDisableSubscription.Length.ShouldBe(1);
            methodDisableSubscriptionPrametersTypes.Length.ShouldBe(1);
            methodDisableSubscriptionPrametersTypes.Length.ShouldBe(parametersOfDisableSubscription.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DisableSubscription) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DisableSubscription_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var methodDisableSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableSubscription = { subscriptionID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodDisableSubscription, parametersOfDisableSubscription, methodDisableSubscriptionPrametersTypes);

            // Assert
            parametersOfDisableSubscription.ShouldNotBeNull();
            parametersOfDisableSubscription.Length.ShouldBe(1);
            methodDisableSubscriptionPrametersTypes.Length.ShouldBe(1);
            methodDisableSubscriptionPrametersTypes.Length.ShouldBe(parametersOfDisableSubscription.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableSubscription) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DisableSubscription_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisableSubscription, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableSubscription) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DisableSubscription_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisableSubscriptionPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodDisableSubscription, Fixture, methodDisableSubscriptionPrametersTypes);

            // Assert
            methodDisableSubscriptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableSubscription) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DisableSubscription_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisableSubscription, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_DeleteSubscription_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSubscriptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodDeleteSubscription, Fixture, methodDeleteSubscriptionPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSubscription_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.DeleteSubscription(subscriptionID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSubscription_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var methodDeleteSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteSubscription = { subscriptionID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteSubscription, methodDeleteSubscriptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfDeleteSubscription);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteSubscription.ShouldNotBeNull();
            parametersOfDeleteSubscription.Length.ShouldBe(1);
            methodDeleteSubscriptionPrametersTypes.Length.ShouldBe(1);
            methodDeleteSubscriptionPrametersTypes.Length.ShouldBe(parametersOfDeleteSubscription.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSubscription_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var methodDeleteSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteSubscription = { subscriptionID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodDeleteSubscription, parametersOfDeleteSubscription, methodDeleteSubscriptionPrametersTypes);

            // Assert
            parametersOfDeleteSubscription.ShouldNotBeNull();
            parametersOfDeleteSubscription.Length.ShouldBe(1);
            methodDeleteSubscriptionPrametersTypes.Length.ShouldBe(1);
            methodDeleteSubscriptionPrametersTypes.Length.ShouldBe(parametersOfDeleteSubscription.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSubscription_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteSubscription, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSubscription_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteSubscriptionPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodDeleteSubscription, Fixture, methodDeleteSubscriptionPrametersTypes);

            // Assert
            methodDeleteSubscriptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_DeleteSubscription_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteSubscription, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListChildren) (Return Type : CatalogItem[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_ListChildren_Method_Call_Internally(Type[] types)
        {
            var methodListChildrenPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListChildren, Fixture, methodListChildrenPrametersTypes);
        }

        #endregion

        #region Method Call : (ListChildren) (Return Type : CatalogItem[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListChildren_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var itemPath = CreateType<string>();
            var recursive = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.ListChildren(itemPath, recursive);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ListChildren) (Return Type : CatalogItem[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListChildren_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var itemPath = CreateType<string>();
            var recursive = CreateType<bool>();
            var methodListChildrenPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfListChildren = { itemPath, recursive };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListChildren, methodListChildrenPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingService, CatalogItem[]>(_reportingServiceInstanceFixture, out exception1, parametersOfListChildren);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingService, CatalogItem[]>(_reportingServiceInstance, MethodListChildren, parametersOfListChildren, methodListChildrenPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfListChildren.ShouldNotBeNull();
            parametersOfListChildren.Length.ShouldBe(2);
            methodListChildrenPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfListChildren));
        }

        #endregion

        #region Method Call : (ListChildren) (Return Type : CatalogItem[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListChildren_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var itemPath = CreateType<string>();
            var recursive = CreateType<bool>();
            var methodListChildrenPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfListChildren = { itemPath, recursive };

            // Assert
            parametersOfListChildren.ShouldNotBeNull();
            parametersOfListChildren.Length.ShouldBe(2);
            methodListChildrenPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService, CatalogItem[]>(_reportingServiceInstance, MethodListChildren, parametersOfListChildren, methodListChildrenPrametersTypes));
        }

        #endregion

        #region Method Call : (ListChildren) (Return Type : CatalogItem[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListChildren_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodListChildrenPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListChildren, Fixture, methodListChildrenPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodListChildrenPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ListChildren) (Return Type : CatalogItem[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListChildren_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListChildrenPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodListChildren, Fixture, methodListChildrenPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodListChildrenPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListChildren) (Return Type : CatalogItem[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListChildren_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListChildren, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListChildren) (Return Type : CatalogItem[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ListChildren_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListChildren, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateSubscription) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_CreateSubscription_Method_Call_Internally(Type[] types)
        {
            var methodCreateSubscriptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodCreateSubscription, Fixture, methodCreateSubscriptionPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateSubscription) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSubscription_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var itemPath = CreateType<string>();
            var extensionSettings = CreateType<ExtensionSettings>();
            var description = CreateType<string>();
            var eventType = CreateType<string>();
            var matchData = CreateType<string>();
            var parameters = CreateType<ParameterValue[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.CreateSubscription(itemPath, extensionSettings, description, eventType, matchData, parameters);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateSubscription) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSubscription_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var itemPath = CreateType<string>();
            var extensionSettings = CreateType<ExtensionSettings>();
            var description = CreateType<string>();
            var eventType = CreateType<string>();
            var matchData = CreateType<string>();
            var parameters = CreateType<ParameterValue[]>();
            var methodCreateSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(ExtensionSettings), typeof(string), typeof(string), typeof(string), typeof(ParameterValue[]) };
            object[] parametersOfCreateSubscription = { itemPath, extensionSettings, description, eventType, matchData, parameters };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateSubscription, methodCreateSubscriptionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingService, string>(_reportingServiceInstanceFixture, out exception1, parametersOfCreateSubscription);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingService, string>(_reportingServiceInstance, MethodCreateSubscription, parametersOfCreateSubscription, methodCreateSubscriptionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateSubscription.ShouldNotBeNull();
            parametersOfCreateSubscription.Length.ShouldBe(6);
            methodCreateSubscriptionPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfCreateSubscription));
        }

        #endregion

        #region Method Call : (CreateSubscription) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSubscription_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var itemPath = CreateType<string>();
            var extensionSettings = CreateType<ExtensionSettings>();
            var description = CreateType<string>();
            var eventType = CreateType<string>();
            var matchData = CreateType<string>();
            var parameters = CreateType<ParameterValue[]>();
            var methodCreateSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(ExtensionSettings), typeof(string), typeof(string), typeof(string), typeof(ParameterValue[]) };
            object[] parametersOfCreateSubscription = { itemPath, extensionSettings, description, eventType, matchData, parameters };

            // Assert
            parametersOfCreateSubscription.ShouldNotBeNull();
            parametersOfCreateSubscription.Length.ShouldBe(6);
            methodCreateSubscriptionPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService, string>(_reportingServiceInstance, MethodCreateSubscription, parametersOfCreateSubscription, methodCreateSubscriptionPrametersTypes));
        }

        #endregion

        #region Method Call : (CreateSubscription) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSubscription_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(ExtensionSettings), typeof(string), typeof(string), typeof(string), typeof(ParameterValue[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodCreateSubscription, Fixture, methodCreateSubscriptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateSubscriptionPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (CreateSubscription) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSubscription_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(ExtensionSettings), typeof(string), typeof(string), typeof(string), typeof(ParameterValue[]) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodCreateSubscription, Fixture, methodCreateSubscriptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateSubscriptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateSubscription) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSubscription_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateSubscription, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateSubscription) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateSubscription_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateSubscription, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ChangeSubscriptionOwner) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_ChangeSubscriptionOwner_Method_Call_Internally(Type[] types)
        {
            var methodChangeSubscriptionOwnerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodChangeSubscriptionOwner, Fixture, methodChangeSubscriptionOwnerPrametersTypes);
        }

        #endregion

        #region Method Call : (ChangeSubscriptionOwner) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ChangeSubscriptionOwner_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var newOwner = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.ChangeSubscriptionOwner(subscriptionID, newOwner);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ChangeSubscriptionOwner) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ChangeSubscriptionOwner_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var newOwner = CreateType<string>();
            var methodChangeSubscriptionOwnerPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfChangeSubscriptionOwner = { subscriptionID, newOwner };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodChangeSubscriptionOwner, methodChangeSubscriptionOwnerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfChangeSubscriptionOwner);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfChangeSubscriptionOwner.ShouldNotBeNull();
            parametersOfChangeSubscriptionOwner.Length.ShouldBe(2);
            methodChangeSubscriptionOwnerPrametersTypes.Length.ShouldBe(2);
            methodChangeSubscriptionOwnerPrametersTypes.Length.ShouldBe(parametersOfChangeSubscriptionOwner.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ChangeSubscriptionOwner) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ChangeSubscriptionOwner_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var newOwner = CreateType<string>();
            var methodChangeSubscriptionOwnerPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfChangeSubscriptionOwner = { subscriptionID, newOwner };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodChangeSubscriptionOwner, parametersOfChangeSubscriptionOwner, methodChangeSubscriptionOwnerPrametersTypes);

            // Assert
            parametersOfChangeSubscriptionOwner.ShouldNotBeNull();
            parametersOfChangeSubscriptionOwner.Length.ShouldBe(2);
            methodChangeSubscriptionOwnerPrametersTypes.Length.ShouldBe(2);
            methodChangeSubscriptionOwnerPrametersTypes.Length.ShouldBe(parametersOfChangeSubscriptionOwner.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ChangeSubscriptionOwner) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ChangeSubscriptionOwner_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodChangeSubscriptionOwner, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ChangeSubscriptionOwner) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ChangeSubscriptionOwner_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodChangeSubscriptionOwnerPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodChangeSubscriptionOwner, Fixture, methodChangeSubscriptionOwnerPrametersTypes);

            // Assert
            methodChangeSubscriptionOwnerPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ChangeSubscriptionOwner) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_ChangeSubscriptionOwner_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodChangeSubscriptionOwner, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSubscriptionProperties) (Return Type : SubscriptionProperties) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_GetSubscriptionProperties_Method_Call_Internally(Type[] types)
        {
            var methodGetSubscriptionPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetSubscriptionProperties, Fixture, methodGetSubscriptionPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSubscriptionProperties) (Return Type : SubscriptionProperties) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSubscriptionProperties_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.GetSubscriptionProperties(subscriptionID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSubscriptionProperties) (Return Type : SubscriptionProperties) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSubscriptionProperties_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var methodGetSubscriptionPropertiesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSubscriptionProperties = { subscriptionID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSubscriptionProperties, methodGetSubscriptionPropertiesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingService, SubscriptionProperties>(_reportingServiceInstanceFixture, out exception1, parametersOfGetSubscriptionProperties);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingService, SubscriptionProperties>(_reportingServiceInstance, MethodGetSubscriptionProperties, parametersOfGetSubscriptionProperties, methodGetSubscriptionPropertiesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSubscriptionProperties.ShouldNotBeNull();
            parametersOfGetSubscriptionProperties.Length.ShouldBe(1);
            methodGetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfGetSubscriptionProperties));
        }

        #endregion

        #region Method Call : (GetSubscriptionProperties) (Return Type : SubscriptionProperties) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSubscriptionProperties_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var methodGetSubscriptionPropertiesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSubscriptionProperties = { subscriptionID };

            // Assert
            parametersOfGetSubscriptionProperties.ShouldNotBeNull();
            parametersOfGetSubscriptionProperties.Length.ShouldBe(1);
            methodGetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService, SubscriptionProperties>(_reportingServiceInstance, MethodGetSubscriptionProperties, parametersOfGetSubscriptionProperties, methodGetSubscriptionPropertiesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSubscriptionProperties) (Return Type : SubscriptionProperties) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSubscriptionProperties_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSubscriptionPropertiesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetSubscriptionProperties, Fixture, methodGetSubscriptionPropertiesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSubscriptionProperties) (Return Type : SubscriptionProperties) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSubscriptionProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSubscriptionPropertiesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetSubscriptionProperties, Fixture, methodGetSubscriptionPropertiesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSubscriptionProperties) (Return Type : SubscriptionProperties) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSubscriptionProperties_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubscriptionProperties, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubscriptionProperties) (Return Type : SubscriptionProperties) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSubscriptionProperties_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSubscriptionProperties, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSubscriptionProperties) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_SetSubscriptionProperties_Method_Call_Internally(Type[] types)
        {
            var methodSetSubscriptionPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodSetSubscriptionProperties, Fixture, methodSetSubscriptionPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSubscriptionProperties) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SetSubscriptionProperties_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var extensionSettings = CreateType<ExtensionSettings>();
            var description = CreateType<string>();
            var eventType = CreateType<string>();
            var matchData = CreateType<string>();
            var parameters = CreateType<ParameterValue[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServiceInstance.SetSubscriptionProperties(subscriptionID, extensionSettings, description, eventType, matchData, parameters);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetSubscriptionProperties) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SetSubscriptionProperties_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var extensionSettings = CreateType<ExtensionSettings>();
            var description = CreateType<string>();
            var eventType = CreateType<string>();
            var matchData = CreateType<string>();
            var parameters = CreateType<ParameterValue[]>();
            var methodSetSubscriptionPropertiesPrametersTypes = new Type[] { typeof(string), typeof(ExtensionSettings), typeof(string), typeof(string), typeof(string), typeof(ParameterValue[]) };
            object[] parametersOfSetSubscriptionProperties = { subscriptionID, extensionSettings, description, eventType, matchData, parameters };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSubscriptionProperties, methodSetSubscriptionPropertiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfSetSubscriptionProperties);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSubscriptionProperties.ShouldNotBeNull();
            parametersOfSetSubscriptionProperties.Length.ShouldBe(6);
            methodSetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(6);
            methodSetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(parametersOfSetSubscriptionProperties.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSubscriptionProperties) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SetSubscriptionProperties_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subscriptionID = CreateType<string>();
            var extensionSettings = CreateType<ExtensionSettings>();
            var description = CreateType<string>();
            var eventType = CreateType<string>();
            var matchData = CreateType<string>();
            var parameters = CreateType<ParameterValue[]>();
            var methodSetSubscriptionPropertiesPrametersTypes = new Type[] { typeof(string), typeof(ExtensionSettings), typeof(string), typeof(string), typeof(string), typeof(ParameterValue[]) };
            object[] parametersOfSetSubscriptionProperties = { subscriptionID, extensionSettings, description, eventType, matchData, parameters };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodSetSubscriptionProperties, parametersOfSetSubscriptionProperties, methodSetSubscriptionPropertiesPrametersTypes);

            // Assert
            parametersOfSetSubscriptionProperties.ShouldNotBeNull();
            parametersOfSetSubscriptionProperties.Length.ShouldBe(6);
            methodSetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(6);
            methodSetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(parametersOfSetSubscriptionProperties.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSubscriptionProperties) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SetSubscriptionProperties_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSubscriptionProperties, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSubscriptionProperties) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SetSubscriptionProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSubscriptionPropertiesPrametersTypes = new Type[] { typeof(string), typeof(ExtensionSettings), typeof(string), typeof(string), typeof(string), typeof(ParameterValue[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodSetSubscriptionProperties, Fixture, methodSetSubscriptionPropertiesPrametersTypes);

            // Assert
            methodSetSubscriptionPropertiesPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSubscriptionProperties) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_SetSubscriptionProperties_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSubscriptionProperties, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSSRSRole) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_GetSSRSRole_Method_Call_Internally(Type[] types)
        {
            var methodGetSSRSRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetSSRSRole, Fixture, methodGetSSRSRolePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSSRSRole) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSSRSRole_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var group = CreateType<string>();
            var methodGetSSRSRolePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSSRSRole = { group };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSSRSRole, methodGetSSRSRolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingService, string>(_reportingServiceInstanceFixture, out exception1, parametersOfGetSSRSRole);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingService, string>(_reportingServiceInstance, MethodGetSSRSRole, parametersOfGetSSRSRole, methodGetSSRSRolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSSRSRole.ShouldNotBeNull();
            parametersOfGetSSRSRole.Length.ShouldBe(1);
            methodGetSSRSRolePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfGetSSRSRole));
        }

        #endregion

        #region Method Call : (GetSSRSRole) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSSRSRole_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var group = CreateType<string>();
            var methodGetSSRSRolePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSSRSRole = { group };

            // Assert
            parametersOfGetSSRSRole.ShouldNotBeNull();
            parametersOfGetSSRSRole.Length.ShouldBe(1);
            methodGetSSRSRolePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService, string>(_reportingServiceInstance, MethodGetSSRSRole, parametersOfGetSSRSRole, methodGetSSRSRolePrametersTypes));
        }

        #endregion

        #region Method Call : (GetSSRSRole) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSSRSRole_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSSRSRolePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetSSRSRole, Fixture, methodGetSSRSRolePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSSRSRolePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSSRSRole) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSSRSRole_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSSRSRolePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodGetSSRSRole, Fixture, methodGetSSRSRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSSRSRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSSRSRole) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSSRSRole_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSSRSRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSSRSRole) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_GetSSRSRole_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSSRSRole, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AssignSsrsRole) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_AssignSsrsRole_Method_Call_Internally(Type[] types)
        {
            var methodAssignSsrsRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodAssignSsrsRole, Fixture, methodAssignSsrsRolePrametersTypes);
        }

        #endregion

        #region Method Call : (AssignSsrsRole) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AssignSsrsRole_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var groups = CreateType<SPGroupCollection>();
            var userList = CreateType<SPList>();
            var role = CreateType<Role>();
            var spRole = CreateType<string>();
            var methodAssignSsrsRolePrametersTypes = new Type[] { typeof(SPGroupCollection), typeof(SPList), typeof(Role), typeof(string) };
            object[] parametersOfAssignSsrsRole = { groups, userList, role, spRole };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAssignSsrsRole, methodAssignSsrsRolePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfAssignSsrsRole);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAssignSsrsRole.ShouldNotBeNull();
            parametersOfAssignSsrsRole.Length.ShouldBe(4);
            methodAssignSsrsRolePrametersTypes.Length.ShouldBe(4);
            methodAssignSsrsRolePrametersTypes.Length.ShouldBe(parametersOfAssignSsrsRole.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AssignSsrsRole) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AssignSsrsRole_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groups = CreateType<SPGroupCollection>();
            var userList = CreateType<SPList>();
            var role = CreateType<Role>();
            var spRole = CreateType<string>();
            var methodAssignSsrsRolePrametersTypes = new Type[] { typeof(SPGroupCollection), typeof(SPList), typeof(Role), typeof(string) };
            object[] parametersOfAssignSsrsRole = { groups, userList, role, spRole };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodAssignSsrsRole, parametersOfAssignSsrsRole, methodAssignSsrsRolePrametersTypes);

            // Assert
            parametersOfAssignSsrsRole.ShouldNotBeNull();
            parametersOfAssignSsrsRole.Length.ShouldBe(4);
            methodAssignSsrsRolePrametersTypes.Length.ShouldBe(4);
            methodAssignSsrsRolePrametersTypes.Length.ShouldBe(parametersOfAssignSsrsRole.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AssignSsrsRole) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AssignSsrsRole_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAssignSsrsRole, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AssignSsrsRole) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AssignSsrsRole_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAssignSsrsRolePrametersTypes = new Type[] { typeof(SPGroupCollection), typeof(SPList), typeof(Role), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodAssignSsrsRole, Fixture, methodAssignSsrsRolePrametersTypes);

            // Assert
            methodAssignSsrsRolePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AssignSsrsRole) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_AssignSsrsRole_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAssignSsrsRole, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadReport) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_UploadReport_Method_Call_Internally(Type[] types)
        {
            var methodUploadReportPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodUploadReport, Fixture, methodUploadReportPrametersTypes);
        }

        #endregion

        #region Method Call : (UploadReport) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_UploadReport_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var siteCollectionId = CreateType<string>();
            var report = CreateType<ReportItem>();
            var methodUploadReportPrametersTypes = new Type[] { typeof(string), typeof(ReportItem) };
            object[] parametersOfUploadReport = { siteCollectionId, report };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUploadReport, methodUploadReportPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfUploadReport);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUploadReport.ShouldNotBeNull();
            parametersOfUploadReport.Length.ShouldBe(2);
            methodUploadReportPrametersTypes.Length.ShouldBe(2);
            methodUploadReportPrametersTypes.Length.ShouldBe(parametersOfUploadReport.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UploadReport) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_UploadReport_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteCollectionId = CreateType<string>();
            var report = CreateType<ReportItem>();
            var methodUploadReportPrametersTypes = new Type[] { typeof(string), typeof(ReportItem) };
            object[] parametersOfUploadReport = { siteCollectionId, report };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodUploadReport, parametersOfUploadReport, methodUploadReportPrametersTypes);

            // Assert
            parametersOfUploadReport.ShouldNotBeNull();
            parametersOfUploadReport.Length.ShouldBe(2);
            methodUploadReportPrametersTypes.Length.ShouldBe(2);
            methodUploadReportPrametersTypes.Length.ShouldBe(parametersOfUploadReport.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadReport) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_UploadReport_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUploadReport, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UploadReport) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_UploadReport_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUploadReportPrametersTypes = new Type[] { typeof(string), typeof(ReportItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodUploadReport, Fixture, methodUploadReportPrametersTypes);

            // Assert
            methodUploadReportPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadReport) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_UploadReport_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUploadReport, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateFoldersIfNotExist) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService_CreateFoldersIfNotExist_Method_Call_Internally(Type[] types)
        {
            var methodCreateFoldersIfNotExistPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodCreateFoldersIfNotExist, Fixture, methodCreateFoldersIfNotExistPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateFoldersIfNotExist) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateFoldersIfNotExist_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var siteCollectionId = CreateType<string>();
            var folder = CreateType<string>();
            var methodCreateFoldersIfNotExistPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreateFoldersIfNotExist = { siteCollectionId, folder };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateFoldersIfNotExist, methodCreateFoldersIfNotExistPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServiceInstanceFixture, parametersOfCreateFoldersIfNotExist);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateFoldersIfNotExist.ShouldNotBeNull();
            parametersOfCreateFoldersIfNotExist.Length.ShouldBe(2);
            methodCreateFoldersIfNotExistPrametersTypes.Length.ShouldBe(2);
            methodCreateFoldersIfNotExistPrametersTypes.Length.ShouldBe(parametersOfCreateFoldersIfNotExist.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateFoldersIfNotExist) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateFoldersIfNotExist_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteCollectionId = CreateType<string>();
            var folder = CreateType<string>();
            var methodCreateFoldersIfNotExistPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreateFoldersIfNotExist = { siteCollectionId, folder };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServiceInstance, MethodCreateFoldersIfNotExist, parametersOfCreateFoldersIfNotExist, methodCreateFoldersIfNotExistPrametersTypes);

            // Assert
            parametersOfCreateFoldersIfNotExist.ShouldNotBeNull();
            parametersOfCreateFoldersIfNotExist.Length.ShouldBe(2);
            methodCreateFoldersIfNotExistPrametersTypes.Length.ShouldBe(2);
            methodCreateFoldersIfNotExistPrametersTypes.Length.ShouldBe(parametersOfCreateFoldersIfNotExist.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateFoldersIfNotExist) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateFoldersIfNotExist_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateFoldersIfNotExist, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateFoldersIfNotExist) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateFoldersIfNotExist_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateFoldersIfNotExistPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServiceInstance, MethodCreateFoldersIfNotExist, Fixture, methodCreateFoldersIfNotExistPrametersTypes);

            // Assert
            methodCreateFoldersIfNotExistPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateFoldersIfNotExist) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService_CreateFoldersIfNotExist_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateFoldersIfNotExist, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}