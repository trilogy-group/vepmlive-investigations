using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using UplandIntegrations.TenroxProjectService;
using ProjectsClient = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.ProjectsClient" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProjectsClientTest : AbstractBaseSetupV3Test
    {
        public ProjectsClientTest() : base(typeof(ProjectsClient))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (ProjectsClient) Initializer

        #region Methods

        private const string MethodQueryByAllSerialized = "QueryByAllSerialized";
        private const string MethodQueryByAllSerializedAsync = "QueryByAllSerializedAsync";
        private const string MethodQueryByUniqueIdSerialized = "QueryByUniqueIdSerialized";
        private const string MethodQueryByUniqueIdSerializedAsync = "QueryByUniqueIdSerializedAsync";
        private const string MethodQueryByIdSerialized = "QueryByIdSerialized";
        private const string MethodQueryByIdSerializedAsync = "QueryByIdSerializedAsync";
        private const string MethodQueryByNameSerialized = "QueryByNameSerialized";
        private const string MethodQueryByNameSerializedAsync = "QueryByNameSerializedAsync";
        private const string MethodDeleteSerialized = "DeleteSerialized";
        private const string MethodDeleteSerializedAsync = "DeleteSerializedAsync";
        private const string MethodDelete = "Delete";
        private const string MethodDeleteAsync = "DeleteAsync";
        private const string MethodBulkDeleteSerialized = "BulkDeleteSerialized";
        private const string MethodBulkDeleteSerializedAsync = "BulkDeleteSerializedAsync";
        private const string MethodBulkDelete = "BulkDelete";
        private const string MethodBulkDeleteAsync = "BulkDeleteAsync";
        private const string MethodQueryBy = "QueryBy";
        private const string MethodQueryByAsync = "QueryByAsync";
        private const string MethodQueryByAll = "QueryByAll";
        private const string MethodQueryByAllAsync = "QueryByAllAsync";
        private const string MethodQueryByUniqueId = "QueryByUniqueId";
        private const string MethodQueryByUniqueIdAsync = "QueryByUniqueIdAsync";
        private const string MethodQueryById = "QueryById";
        private const string MethodQueryByIdAsync = "QueryByIdAsync";
        private const string MethodQueryByName = "QueryByName";
        private const string MethodQueryByNameAsync = "QueryByNameAsync";
        private const string MethodQueryByParentId = "QueryByParentId";
        private const string MethodQueryByParentIdAsync = "QueryByParentIdAsync";
        private const string MethodQueryByEndDate = "QueryByEndDate";
        private const string MethodQueryByEndDateAsync = "QueryByEndDateAsync";
        private const string MethodQueryByBudgetExceeded = "QueryByBudgetExceeded";
        private const string MethodQueryByBudgetExceededAsync = "QueryByBudgetExceededAsync";
        private const string MethodSave = "Save";
        private const string MethodSaveAsync = "SaveAsync";
        private const string MethodSaveAll = "SaveAll";
        private const string MethodSaveAllAsync = "SaveAllAsync";
        private const string MethodCreateNew = "CreateNew";
        private const string MethodCreateNewAsync = "CreateNewAsync";
        private const string MethodOptomisticSave = "OptomisticSave";
        private const string MethodOptomisticSaveAsync = "OptomisticSaveAsync";
        private const string MethodUpdateSegmentEntries = "UpdateSegmentEntries";
        private const string MethodUpdateSegmentEntriesAsync = "UpdateSegmentEntriesAsync";
        private const string MethodAddBusinessUnits = "AddBusinessUnits";
        private const string MethodAddBusinessUnitsAsync = "AddBusinessUnitsAsync";
        private const string MethodRemoveBusinessUnits = "RemoveBusinessUnits";
        private const string MethodRemoveBusinessUnitsAsync = "RemoveBusinessUnitsAsync";
        private const string MethodCreateBillingRule = "CreateBillingRule";
        private const string MethodCreateBillingRuleAsync = "CreateBillingRuleAsync";

        #endregion

        private Type _projectsClientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ProjectsClient _projectsClientInstance;
        private ProjectsClient _projectsClientInstanceFixture;

        #region General Initializer : Class (ProjectsClient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProjectsClient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _projectsClientInstanceType = typeof(ProjectsClient);
            _projectsClientInstanceFixture = this.Create<ProjectsClient>(true);
            _projectsClientInstance = _projectsClientInstanceFixture ?? this.Create<ProjectsClient>(false);
            CurrentInstance = _projectsClientInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProjectsClient) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ProjectsClient" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_ProjectsClient_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ProjectsClient>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ProjectsClient>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfProjectsClient = {  };
            Type [] methodProjectsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_projectsClientInstanceType, methodProjectsClientPrametersTypes, parametersOfProjectsClient);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodProjectsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_projectsClientInstanceType, Fixture, methodProjectsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            object[] parametersOfProjectsClient = { endpointConfigurationName };
            var methodProjectsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_projectsClientInstanceType, methodProjectsClientPrametersTypes, parametersOfProjectsClient);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodProjectsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_projectsClientInstanceType, Fixture, methodProjectsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<string>();
            object[] parametersOfProjectsClient = { endpointConfigurationName, remoteAddress };
            var methodProjectsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_projectsClientInstanceType, methodProjectsClientPrametersTypes, parametersOfProjectsClient);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodProjectsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_projectsClientInstanceType, Fixture, methodProjectsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfProjectsClient = { endpointConfigurationName, remoteAddress };
            var methodProjectsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_projectsClientInstanceType, methodProjectsClientPrametersTypes, parametersOfProjectsClient);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodProjectsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_projectsClientInstanceType, Fixture, methodProjectsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var binding = this.CreateType<System.ServiceModel.Channels.Binding>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfProjectsClient = { binding, remoteAddress };
            var methodProjectsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_projectsClientInstanceType, methodProjectsClientPrametersTypes, parametersOfProjectsClient);
        }

        #endregion

        #region General Constructor : Class (ProjectsClient) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ProjectsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ProjectsClient_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodProjectsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_projectsClientInstanceType, Fixture, methodProjectsClientPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (QueryByAllSerialized) (Return Type : UplandIntegrations.TenroxProjectService.QueryByAllSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByAllSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAllSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByAllSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : UplandIntegrations.TenroxProjectService.QueryByUniqueIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByUniqueIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByUniqueIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : UplandIntegrations.TenroxProjectService.QueryByIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : UplandIntegrations.TenroxProjectService.QueryByNameSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByNameSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByNameSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : UplandIntegrations.TenroxProjectService.DeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_DeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_DeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : UplandIntegrations.TenroxProjectService.DeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_Delete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : UplandIntegrations.TenroxProjectService.BulkDeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_BulkDeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_BulkDeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : UplandIntegrations.TenroxProjectService.BulkDeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_BulkDelete_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_BulkDelete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryBy) (Return Type : UplandIntegrations.TenroxProjectService.Project[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryBy_Method_Call_Internally(Type[] types)
        {
            var methodQueryByPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryBy, Fixture, methodQueryByPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAll) (Return Type : UplandIntegrations.TenroxProjectService.Project[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByAll_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByAll, Fixture, methodQueryByAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueId) (Return Type : UplandIntegrations.TenroxProjectService.Project) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByUniqueId_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByUniqueId, Fixture, methodQueryByUniqueIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryById) (Return Type : UplandIntegrations.TenroxProjectService.Project[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryById_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryById, Fixture, methodQueryByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByName) (Return Type : UplandIntegrations.TenroxProjectService.Project[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByName_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByName, Fixture, methodQueryByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByParentId) (Return Type : UplandIntegrations.TenroxProjectService.Project[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByParentId_Method_Call_Internally(Type[] types)
        {
            var methodQueryByParentIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByParentId, Fixture, methodQueryByParentIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByEndDate) (Return Type : UplandIntegrations.TenroxProjectService.Project[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByEndDate_Method_Call_Internally(Type[] types)
        {
            var methodQueryByEndDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByEndDate, Fixture, methodQueryByEndDatePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByBudgetExceeded) (Return Type : UplandIntegrations.TenroxProjectService.Project[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_QueryByBudgetExceeded_Method_Call_Internally(Type[] types)
        {
            var methodQueryByBudgetExceededPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodQueryByBudgetExceeded, Fixture, methodQueryByBudgetExceededPrametersTypes);
        }

        #endregion

        #region Method Call : (Save) (Return Type : UplandIntegrations.TenroxProjectService.Project) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_Save_Method_Call_Internally(Type[] types)
        {
            var methodSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodSave, Fixture, methodSavePrametersTypes);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : UplandIntegrations.TenroxProjectService.Project[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_SaveAll_Method_Call_Internally(Type[] types)
        {
            var methodSaveAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodSaveAll, Fixture, methodSaveAllPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateNew) (Return Type : UplandIntegrations.TenroxProjectService.Project) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_CreateNew_Method_Call_Internally(Type[] types)
        {
            var methodCreateNewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodCreateNew, Fixture, methodCreateNewPrametersTypes);
        }

        #endregion

        #region Method Call : (OptomisticSave) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_OptomisticSave_Method_Call_Internally(Type[] types)
        {
            var methodOptomisticSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodOptomisticSave, Fixture, methodOptomisticSavePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateSegmentEntries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_UpdateSegmentEntries_Method_Call_Internally(Type[] types)
        {
            var methodUpdateSegmentEntriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodUpdateSegmentEntries, Fixture, methodUpdateSegmentEntriesPrametersTypes);
        }

        #endregion

        #region Method Call : (AddBusinessUnits) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_AddBusinessUnits_Method_Call_Internally(Type[] types)
        {
            var methodAddBusinessUnitsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodAddBusinessUnits, Fixture, methodAddBusinessUnitsPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveBusinessUnits) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_RemoveBusinessUnits_Method_Call_Internally(Type[] types)
        {
            var methodRemoveBusinessUnitsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodRemoveBusinessUnits, Fixture, methodRemoveBusinessUnitsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateBillingRule) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ProjectsClient_CreateBillingRule_Method_Call_Internally(Type[] types)
        {
            var methodCreateBillingRulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectsClientInstance, MethodCreateBillingRule, Fixture, methodCreateBillingRulePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}