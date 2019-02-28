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
using UplandIntegrations.TenroxIntegrationService;
using IntegrationsClient = UplandIntegrations.TenroxIntegrationService;

namespace UplandIntegrations.TenroxIntegrationService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxIntegrationService.IntegrationsClient" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxIntegrationService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class IntegrationsClientTest : AbstractBaseSetupV3Test
    {
        public IntegrationsClientTest() : base(typeof(IntegrationsClient))
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

        #region General Initializer : Class (IntegrationsClient) Initializer

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
        private const string MethodSave = "Save";
        private const string MethodSaveAsync = "SaveAsync";
        private const string MethodSaveAll = "SaveAll";
        private const string MethodSaveAllAsync = "SaveAllAsync";
        private const string MethodQueryById = "QueryById";
        private const string MethodQueryByIdAsync = "QueryByIdAsync";
        private const string MethodQueryByName = "QueryByName";
        private const string MethodQueryByNameAsync = "QueryByNameAsync";
        private const string MethodQueryByObjectTypeObjectID = "QueryByObjectTypeObjectID";
        private const string MethodQueryByObjectTypeObjectIDAsync = "QueryByObjectTypeObjectIDAsync";

        #endregion

        private Type _integrationsClientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private IntegrationsClient _integrationsClientInstance;
        private IntegrationsClient _integrationsClientInstanceFixture;

        #region General Initializer : Class (IntegrationsClient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="IntegrationsClient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _integrationsClientInstanceType = typeof(IntegrationsClient);
            _integrationsClientInstanceFixture = this.Create<IntegrationsClient>(true);
            _integrationsClientInstance = _integrationsClientInstanceFixture ?? this.Create<IntegrationsClient>(false);
            CurrentInstance = _integrationsClientInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (IntegrationsClient) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="IntegrationsClient" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_IntegrationsClient_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<IntegrationsClient>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<IntegrationsClient>(Fixture);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfIntegrationsClient = {  };
            Type [] methodIntegrationsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_integrationsClientInstanceType, methodIntegrationsClientPrametersTypes, parametersOfIntegrationsClient);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodIntegrationsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_integrationsClientInstanceType, Fixture, methodIntegrationsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            object[] parametersOfIntegrationsClient = { endpointConfigurationName };
            var methodIntegrationsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_integrationsClientInstanceType, methodIntegrationsClientPrametersTypes, parametersOfIntegrationsClient);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodIntegrationsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_integrationsClientInstanceType, Fixture, methodIntegrationsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<string>();
            object[] parametersOfIntegrationsClient = { endpointConfigurationName, remoteAddress };
            var methodIntegrationsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_integrationsClientInstanceType, methodIntegrationsClientPrametersTypes, parametersOfIntegrationsClient);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodIntegrationsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_integrationsClientInstanceType, Fixture, methodIntegrationsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfIntegrationsClient = { endpointConfigurationName, remoteAddress };
            var methodIntegrationsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_integrationsClientInstanceType, methodIntegrationsClientPrametersTypes, parametersOfIntegrationsClient);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodIntegrationsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_integrationsClientInstanceType, Fixture, methodIntegrationsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var binding = this.CreateType<System.ServiceModel.Channels.Binding>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfIntegrationsClient = { binding, remoteAddress };
            var methodIntegrationsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_integrationsClientInstanceType, methodIntegrationsClientPrametersTypes, parametersOfIntegrationsClient);
        }

        #endregion

        #region General Constructor : Class (IntegrationsClient) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="IntegrationsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationsClient_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodIntegrationsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_integrationsClientInstanceType, Fixture, methodIntegrationsClientPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (QueryByAllSerialized) (Return Type : UplandIntegrations.TenroxIntegrationService.QueryByAllSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByAllSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAllSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByAllSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : UplandIntegrations.TenroxIntegrationService.QueryByUniqueIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByUniqueIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByUniqueIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : UplandIntegrations.TenroxIntegrationService.QueryByIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : UplandIntegrations.TenroxIntegrationService.QueryByNameSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByNameSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByNameSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : UplandIntegrations.TenroxIntegrationService.DeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_DeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_DeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : UplandIntegrations.TenroxIntegrationService.DeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_Delete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : UplandIntegrations.TenroxIntegrationService.BulkDeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_BulkDeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_BulkDeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : UplandIntegrations.TenroxIntegrationService.BulkDeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_BulkDelete_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_BulkDelete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAll) (Return Type : UplandIntegrations.TenroxIntegrationService.Integration[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByAll_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByAll, Fixture, methodQueryByAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueId) (Return Type : UplandIntegrations.TenroxIntegrationService.Integration) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByUniqueId_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByUniqueId, Fixture, methodQueryByUniqueIdPrametersTypes);
        }

        #endregion

        #region Method Call : (Save) (Return Type : UplandIntegrations.TenroxIntegrationService.Integration) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_Save_Method_Call_Internally(Type[] types)
        {
            var methodSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodSave, Fixture, methodSavePrametersTypes);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : UplandIntegrations.TenroxIntegrationService.Integration[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_SaveAll_Method_Call_Internally(Type[] types)
        {
            var methodSaveAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodSaveAll, Fixture, methodSaveAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryById) (Return Type : UplandIntegrations.TenroxIntegrationService.Integration[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryById_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryById, Fixture, methodQueryByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByName) (Return Type : UplandIntegrations.TenroxIntegrationService.Integration[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByName_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByName, Fixture, methodQueryByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByObjectTypeObjectID) (Return Type : UplandIntegrations.TenroxIntegrationService.Integration[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationsClient_QueryByObjectTypeObjectID_Method_Call_Internally(Type[] types)
        {
            var methodQueryByObjectTypeObjectIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationsClientInstance, MethodQueryByObjectTypeObjectID, Fixture, methodQueryByObjectTypeObjectIDPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}