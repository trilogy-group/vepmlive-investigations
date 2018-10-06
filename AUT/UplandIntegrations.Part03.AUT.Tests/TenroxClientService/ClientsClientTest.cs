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
using UplandIntegrations.TenroxClientService;
using ClientsClient = UplandIntegrations.TenroxClientService;

namespace UplandIntegrations.TenroxClientService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxClientService.ClientsClient" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxClientService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ClientsClientTest : AbstractBaseSetupV3Test
    {
        public ClientsClientTest() : base(typeof(ClientsClient))
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

        #region General Initializer : Class (ClientsClient) Initializer

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
        private const string MethodQueryByAll = "QueryByAll";
        private const string MethodQueryByAllAsync = "QueryByAllAsync";
        private const string MethodQueryByUniqueId = "QueryByUniqueId";
        private const string MethodQueryByUniqueIdAsync = "QueryByUniqueIdAsync";
        private const string MethodQueryById = "QueryById";
        private const string MethodQueryByIdAsync = "QueryByIdAsync";
        private const string MethodQueryByName = "QueryByName";
        private const string MethodQueryByNameAsync = "QueryByNameAsync";
        private const string MethodSave = "Save";
        private const string MethodSaveAsync = "SaveAsync";
        private const string MethodSaveAll = "SaveAll";
        private const string MethodSaveAllAsync = "SaveAllAsync";
        private const string MethodQueryByAllWithNonPlaceholders = "QueryByAllWithNonPlaceholders";
        private const string MethodQueryByAllWithNonPlaceholdersAsync = "QueryByAllWithNonPlaceholdersAsync";
        private const string MethodQueryByUniqueIdDXUserId = "QueryByUniqueIdDXUserId";
        private const string MethodQueryByUniqueIdDXUserIdAsync = "QueryByUniqueIdDXUserIdAsync";
        private const string MethodQueryByClientId = "QueryByClientId";
        private const string MethodQueryByClientIdAsync = "QueryByClientIdAsync";
        private const string MethodCreateNew = "CreateNew";
        private const string MethodCreateNewAsync = "CreateNewAsync";
        private const string MethodOptomisticSave = "OptomisticSave";
        private const string MethodOptomisticSaveAsync = "OptomisticSaveAsync";

        #endregion

        private Type _clientsClientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ClientsClient _clientsClientInstance;
        private ClientsClient _clientsClientInstanceFixture;

        #region General Initializer : Class (ClientsClient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ClientsClient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clientsClientInstanceType = typeof(ClientsClient);
            _clientsClientInstanceFixture = this.Create<ClientsClient>(true);
            _clientsClientInstance = _clientsClientInstanceFixture ?? this.Create<ClientsClient>(false);
            CurrentInstance = _clientsClientInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ClientsClient) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ClientsClient" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_ClientsClient_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ClientsClient>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ClientsClient>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfClientsClient = {  };
            Type [] methodClientsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_clientsClientInstanceType, methodClientsClientPrametersTypes, parametersOfClientsClient);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodClientsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_clientsClientInstanceType, Fixture, methodClientsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            object[] parametersOfClientsClient = { endpointConfigurationName };
            var methodClientsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_clientsClientInstanceType, methodClientsClientPrametersTypes, parametersOfClientsClient);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodClientsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_clientsClientInstanceType, Fixture, methodClientsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<string>();
            object[] parametersOfClientsClient = { endpointConfigurationName, remoteAddress };
            var methodClientsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_clientsClientInstanceType, methodClientsClientPrametersTypes, parametersOfClientsClient);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodClientsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_clientsClientInstanceType, Fixture, methodClientsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfClientsClient = { endpointConfigurationName, remoteAddress };
            var methodClientsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_clientsClientInstanceType, methodClientsClientPrametersTypes, parametersOfClientsClient);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodClientsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_clientsClientInstanceType, Fixture, methodClientsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var binding = this.CreateType<System.ServiceModel.Channels.Binding>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfClientsClient = { binding, remoteAddress };
            var methodClientsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_clientsClientInstanceType, methodClientsClientPrametersTypes, parametersOfClientsClient);
        }

        #endregion

        #region General Constructor : Class (ClientsClient) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ClientsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClientsClient_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodClientsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_clientsClientInstanceType, Fixture, methodClientsClientPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (QueryByAllSerialized) (Return Type : UplandIntegrations.TenroxClientService.QueryByAllSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByAllSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAllSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByAllSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : UplandIntegrations.TenroxClientService.QueryByUniqueIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByUniqueIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByUniqueIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : UplandIntegrations.TenroxClientService.QueryByIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : UplandIntegrations.TenroxClientService.QueryByNameSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByNameSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByNameSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : UplandIntegrations.TenroxClientService.DeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_DeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_DeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : UplandIntegrations.TenroxClientService.DeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_Delete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : UplandIntegrations.TenroxClientService.BulkDeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_BulkDeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_BulkDeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : UplandIntegrations.TenroxClientService.BulkDeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_BulkDelete_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_BulkDelete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAll) (Return Type : UplandIntegrations.TenroxClientService.Client[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByAll_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByAll, Fixture, methodQueryByAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueId) (Return Type : UplandIntegrations.TenroxClientService.Client) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByUniqueId_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByUniqueId, Fixture, methodQueryByUniqueIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryById) (Return Type : UplandIntegrations.TenroxClientService.Client[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryById_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryById, Fixture, methodQueryByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByName) (Return Type : UplandIntegrations.TenroxClientService.Client[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByName_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByName, Fixture, methodQueryByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (Save) (Return Type : UplandIntegrations.TenroxClientService.Client) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_Save_Method_Call_Internally(Type[] types)
        {
            var methodSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodSave, Fixture, methodSavePrametersTypes);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : UplandIntegrations.TenroxClientService.Client[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_SaveAll_Method_Call_Internally(Type[] types)
        {
            var methodSaveAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodSaveAll, Fixture, methodSaveAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAllWithNonPlaceholders) (Return Type : UplandIntegrations.TenroxClientService.Client[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByAllWithNonPlaceholders_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllWithNonPlaceholdersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByAllWithNonPlaceholders, Fixture, methodQueryByAllWithNonPlaceholdersPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdDXUserId) (Return Type : UplandIntegrations.TenroxClientService.Client[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByUniqueIdDXUserId_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdDXUserIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByUniqueIdDXUserId, Fixture, methodQueryByUniqueIdDXUserIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByClientId) (Return Type : UplandIntegrations.TenroxClientService.ClientInvoiceOption) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_QueryByClientId_Method_Call_Internally(Type[] types)
        {
            var methodQueryByClientIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodQueryByClientId, Fixture, methodQueryByClientIdPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateNew) (Return Type : UplandIntegrations.TenroxClientService.Client) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_CreateNew_Method_Call_Internally(Type[] types)
        {
            var methodCreateNewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodCreateNew, Fixture, methodCreateNewPrametersTypes);
        }

        #endregion

        #region Method Call : (OptomisticSave) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientsClient_OptomisticSave_Method_Call_Internally(Type[] types)
        {
            var methodOptomisticSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientsClientInstance, MethodOptomisticSave, Fixture, methodOptomisticSavePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}