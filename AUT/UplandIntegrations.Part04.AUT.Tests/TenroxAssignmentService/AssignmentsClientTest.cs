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
using UplandIntegrations.TenroxAssignmentService;
using AssignmentsClient = UplandIntegrations.TenroxAssignmentService;

namespace UplandIntegrations.TenroxAssignmentService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAssignmentService.AssignmentsClient" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAssignmentService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AssignmentsClientTest : AbstractBaseSetupV3Test
    {
        public AssignmentsClientTest() : base(typeof(AssignmentsClient))
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

        #region General Initializer : Class (AssignmentsClient) Initializer

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
        private const string MethodSave = "Save";
        private const string MethodSaveAsync = "SaveAsync";
        private const string MethodSaveAll = "SaveAll";
        private const string MethodSaveAllAsync = "SaveAllAsync";
        private const string MethodQueryById = "QueryById";
        private const string MethodQueryByIdAsync = "QueryByIdAsync";
        private const string MethodQueryByName = "QueryByName";
        private const string MethodQueryByNameAsync = "QueryByNameAsync";
        private const string MethodCreateNew = "CreateNew";
        private const string MethodCreateNewAsync = "CreateNewAsync";
        private const string MethodOptomisticSave = "OptomisticSave";
        private const string MethodOptomisticSaveAsync = "OptomisticSaveAsync";

        #endregion

        private Type _assignmentsClientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private AssignmentsClient _assignmentsClientInstance;
        private AssignmentsClient _assignmentsClientInstanceFixture;

        #region General Initializer : Class (AssignmentsClient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssignmentsClient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _assignmentsClientInstanceType = typeof(AssignmentsClient);
            _assignmentsClientInstanceFixture = this.Create<AssignmentsClient>(true);
            _assignmentsClientInstance = _assignmentsClientInstanceFixture ?? this.Create<AssignmentsClient>(false);
            CurrentInstance = _assignmentsClientInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AssignmentsClient) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="AssignmentsClient" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_AssignmentsClient_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<AssignmentsClient>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<AssignmentsClient>(Fixture);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfAssignmentsClient = {  };
            Type [] methodAssignmentsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_assignmentsClientInstanceType, methodAssignmentsClientPrametersTypes, parametersOfAssignmentsClient);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodAssignmentsClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_assignmentsClientInstanceType, Fixture, methodAssignmentsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            object[] parametersOfAssignmentsClient = { endpointConfigurationName };
            var methodAssignmentsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_assignmentsClientInstanceType, methodAssignmentsClientPrametersTypes, parametersOfAssignmentsClient);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodAssignmentsClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_assignmentsClientInstanceType, Fixture, methodAssignmentsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<string>();
            object[] parametersOfAssignmentsClient = { endpointConfigurationName, remoteAddress };
            var methodAssignmentsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_assignmentsClientInstanceType, methodAssignmentsClientPrametersTypes, parametersOfAssignmentsClient);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodAssignmentsClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_assignmentsClientInstanceType, Fixture, methodAssignmentsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfAssignmentsClient = { endpointConfigurationName, remoteAddress };
            var methodAssignmentsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_assignmentsClientInstanceType, methodAssignmentsClientPrametersTypes, parametersOfAssignmentsClient);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodAssignmentsClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_assignmentsClientInstanceType, Fixture, methodAssignmentsClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var binding = this.CreateType<System.ServiceModel.Channels.Binding>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfAssignmentsClient = { binding, remoteAddress };
            var methodAssignmentsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_assignmentsClientInstanceType, methodAssignmentsClientPrametersTypes, parametersOfAssignmentsClient);
        }

        #endregion

        #region General Constructor : Class (AssignmentsClient) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AssignmentsClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AssignmentsClient_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodAssignmentsClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_assignmentsClientInstanceType, Fixture, methodAssignmentsClientPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (QueryByAllSerialized) (Return Type : UplandIntegrations.TenroxAssignmentService.QueryByAllSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByAllSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAllSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByAllSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : UplandIntegrations.TenroxAssignmentService.QueryByUniqueIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByUniqueIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByUniqueIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : UplandIntegrations.TenroxAssignmentService.QueryByIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : UplandIntegrations.TenroxAssignmentService.QueryByNameSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByNameSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByNameSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : UplandIntegrations.TenroxAssignmentService.DeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_DeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_DeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : UplandIntegrations.TenroxAssignmentService.DeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_Delete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : UplandIntegrations.TenroxAssignmentService.BulkDeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_BulkDeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_BulkDeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : UplandIntegrations.TenroxAssignmentService.BulkDeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_BulkDelete_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_BulkDelete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryBy) (Return Type : UplandIntegrations.TenroxAssignmentService.Assignment[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryBy_Method_Call_Internally(Type[] types)
        {
            var methodQueryByPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryBy, Fixture, methodQueryByPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAll) (Return Type : UplandIntegrations.TenroxAssignmentService.Assignment[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByAll_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByAll, Fixture, methodQueryByAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueId) (Return Type : UplandIntegrations.TenroxAssignmentService.Assignment) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByUniqueId_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByUniqueId, Fixture, methodQueryByUniqueIdPrametersTypes);
        }

        #endregion

        #region Method Call : (Save) (Return Type : UplandIntegrations.TenroxAssignmentService.Assignment) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_Save_Method_Call_Internally(Type[] types)
        {
            var methodSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodSave, Fixture, methodSavePrametersTypes);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : UplandIntegrations.TenroxAssignmentService.Assignment[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_SaveAll_Method_Call_Internally(Type[] types)
        {
            var methodSaveAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodSaveAll, Fixture, methodSaveAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryById) (Return Type : UplandIntegrations.TenroxAssignmentService.Assignment[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryById_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryById, Fixture, methodQueryByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByName) (Return Type : UplandIntegrations.TenroxAssignmentService.Assignment[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_QueryByName_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodQueryByName, Fixture, methodQueryByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateNew) (Return Type : UplandIntegrations.TenroxAssignmentService.Assignment) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_CreateNew_Method_Call_Internally(Type[] types)
        {
            var methodCreateNewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodCreateNew, Fixture, methodCreateNewPrametersTypes);
        }

        #endregion

        #region Method Call : (OptomisticSave) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentsClient_OptomisticSave_Method_Call_Internally(Type[] types)
        {
            var methodOptomisticSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentsClientInstance, MethodOptomisticSave, Fixture, methodOptomisticSavePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}