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
using UplandIntegrations.TenroxDataService;
using ExecuteStoredProcedureClient = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.ExecuteStoredProcedureClient" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ExecuteStoredProcedureClientTest : AbstractBaseSetupV3Test
    {
        public ExecuteStoredProcedureClientTest() : base(typeof(ExecuteStoredProcedureClient))
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

        #region General Initializer : Class (ExecuteStoredProcedureClient) Initializer

        #region Methods

        private const string MethodRunStoredProcedure = "RunStoredProcedure";
        private const string MethodRunStoredProcedureAsync = "RunStoredProcedureAsync";
        private const string MethodRunStoredProcedureExecute = "RunStoredProcedureExecute";
        private const string MethodRunStoredProcedureExecuteAsync = "RunStoredProcedureExecuteAsync";
        private const string MethodRunStoredProcedureNonQuery = "RunStoredProcedureNonQuery";
        private const string MethodRunStoredProcedureNonQueryAsync = "RunStoredProcedureNonQueryAsync";
        private const string MethodRunStoredProcedureScalar = "RunStoredProcedureScalar";
        private const string MethodRunStoredProcedureScalarAsync = "RunStoredProcedureScalarAsync";
        private const string MethodRunStoredProcedureDataSet = "RunStoredProcedureDataSet";
        private const string MethodRunStoredProcedureDataSetAsync = "RunStoredProcedureDataSetAsync";
        private const string MethodRunStoredProcedureSerialized = "RunStoredProcedureSerialized";
        private const string MethodRunStoredProcedureSerializedAsync = "RunStoredProcedureSerializedAsync";
        private const string MethodProcessErrorMessages = "ProcessErrorMessages";
        private const string MethodProcessErrorMessagesAsync = "ProcessErrorMessagesAsync";

        #endregion

        private Type _executeStoredProcedureClientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ExecuteStoredProcedureClient _executeStoredProcedureClientInstance;
        private ExecuteStoredProcedureClient _executeStoredProcedureClientInstanceFixture;

        #region General Initializer : Class (ExecuteStoredProcedureClient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExecuteStoredProcedureClient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _executeStoredProcedureClientInstanceType = typeof(ExecuteStoredProcedureClient);
            _executeStoredProcedureClientInstanceFixture = this.Create<ExecuteStoredProcedureClient>(true);
            _executeStoredProcedureClientInstance = _executeStoredProcedureClientInstanceFixture ?? this.Create<ExecuteStoredProcedureClient>(false);
            CurrentInstance = _executeStoredProcedureClientInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ExecuteStoredProcedureClient" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_ExecuteStoredProcedureClient_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ExecuteStoredProcedureClient>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ExecuteStoredProcedureClient>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfExecuteStoredProcedureClient = {  };
            Type [] methodExecuteStoredProcedureClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_executeStoredProcedureClientInstanceType, methodExecuteStoredProcedureClientPrametersTypes, parametersOfExecuteStoredProcedureClient);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodExecuteStoredProcedureClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_executeStoredProcedureClientInstanceType, Fixture, methodExecuteStoredProcedureClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            object[] parametersOfExecuteStoredProcedureClient = { endpointConfigurationName };
            var methodExecuteStoredProcedureClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_executeStoredProcedureClientInstanceType, methodExecuteStoredProcedureClientPrametersTypes, parametersOfExecuteStoredProcedureClient);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodExecuteStoredProcedureClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_executeStoredProcedureClientInstanceType, Fixture, methodExecuteStoredProcedureClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<string>();
            object[] parametersOfExecuteStoredProcedureClient = { endpointConfigurationName, remoteAddress };
            var methodExecuteStoredProcedureClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_executeStoredProcedureClientInstanceType, methodExecuteStoredProcedureClientPrametersTypes, parametersOfExecuteStoredProcedureClient);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodExecuteStoredProcedureClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_executeStoredProcedureClientInstanceType, Fixture, methodExecuteStoredProcedureClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfExecuteStoredProcedureClient = { endpointConfigurationName, remoteAddress };
            var methodExecuteStoredProcedureClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_executeStoredProcedureClientInstanceType, methodExecuteStoredProcedureClientPrametersTypes, parametersOfExecuteStoredProcedureClient);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodExecuteStoredProcedureClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_executeStoredProcedureClientInstanceType, Fixture, methodExecuteStoredProcedureClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var binding = this.CreateType<System.ServiceModel.Channels.Binding>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfExecuteStoredProcedureClient = { binding, remoteAddress };
            var methodExecuteStoredProcedureClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_executeStoredProcedureClientInstanceType, methodExecuteStoredProcedureClientPrametersTypes, parametersOfExecuteStoredProcedureClient);
        }

        #endregion

        #region General Constructor : Class (ExecuteStoredProcedureClient) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ExecuteStoredProcedureClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExecuteStoredProcedureClient_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodExecuteStoredProcedureClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_executeStoredProcedureClientInstanceType, Fixture, methodExecuteStoredProcedureClientPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (RunStoredProcedure) (Return Type : UplandIntegrations.TenroxDataService.RunStoredProcedureResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedure_Method_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedurePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedure, Fixture, methodRunStoredProcedurePrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedure) (Return Type : System.Data.DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedure_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedurePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedure, Fixture, methodRunStoredProcedurePrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureExecute) (Return Type : UplandIntegrations.TenroxDataService.RunStoredProcedureExecuteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureExecute_Method_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureExecute, Fixture, methodRunStoredProcedureExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureExecute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureExecute_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureExecute, Fixture, methodRunStoredProcedureExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureNonQuery) (Return Type : UplandIntegrations.TenroxDataService.RunStoredProcedureNonQueryResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureNonQuery_Method_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureNonQuery, Fixture, methodRunStoredProcedureNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureNonQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureNonQuery_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureNonQuery, Fixture, methodRunStoredProcedureNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureScalar) (Return Type : UplandIntegrations.TenroxDataService.RunStoredProcedureScalarResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureScalar_Method_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureScalarPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureScalar, Fixture, methodRunStoredProcedureScalarPrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureScalar) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureScalar_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureScalarPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureScalar, Fixture, methodRunStoredProcedureScalarPrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureDataSet) (Return Type : UplandIntegrations.TenroxDataService.RunStoredProcedureDataSetResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureDataSet_Method_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureDataSetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureDataSet, Fixture, methodRunStoredProcedureDataSetPrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureDataSet) (Return Type : System.Data.DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureDataSet_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureDataSetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureDataSet, Fixture, methodRunStoredProcedureDataSetPrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureSerialized) (Return Type : UplandIntegrations.TenroxDataService.RunStoredProcedureSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureSerialized_Method_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureSerialized, Fixture, methodRunStoredProcedureSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (RunStoredProcedureSerialized) (Return Type : System.Data.DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_RunStoredProcedureSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRunStoredProcedureSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodRunStoredProcedureSerialized, Fixture, methodRunStoredProcedureSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessErrorMessages) (Return Type : UplandIntegrations.TenroxDataService.ProcessErrorMessagesResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_ProcessErrorMessages_Method_Call_Internally(Type[] types)
        {
            var methodProcessErrorMessagesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodProcessErrorMessages, Fixture, methodProcessErrorMessagesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessErrorMessages) (Return Type : System.Data.DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExecuteStoredProcedureClient_ProcessErrorMessages_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodProcessErrorMessagesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_executeStoredProcedureClientInstance, MethodProcessErrorMessages, Fixture, methodProcessErrorMessagesPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}