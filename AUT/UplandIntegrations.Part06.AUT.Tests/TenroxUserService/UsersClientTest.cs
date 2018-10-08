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
using UplandIntegrations.TenroxUserService;
using UsersClient = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.UsersClient" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class UsersClientTest : AbstractBaseSetupV3Test
    {
        public UsersClientTest() : base(typeof(UsersClient))
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

        #region General Initializer : Class (UsersClient) Initializer

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
        private const string MethodQueryByAllSimple = "QueryByAllSimple";
        private const string MethodQueryByAllSimpleAsync = "QueryByAllSimpleAsync";
        private const string MethodQueryByAllActiveSimple = "QueryByAllActiveSimple";
        private const string MethodQueryByAllActiveSimpleAsync = "QueryByAllActiveSimpleAsync";
        private const string MethodFindSimpleUsersByName = "FindSimpleUsersByName";
        private const string MethodFindSimpleUsersByNameAsync = "FindSimpleUsersByNameAsync";
        private const string MethodFindSimpleUsersByEmail = "FindSimpleUsersByEmail";
        private const string MethodFindSimpleUsersByEmailAsync = "FindSimpleUsersByEmailAsync";
        private const string MethodGetAllSimpleUsers = "GetAllSimpleUsers";
        private const string MethodGetAllSimpleUsersAsync = "GetAllSimpleUsersAsync";
        private const string MethodGetSimpleUserByLogonName = "GetSimpleUserByLogonName";
        private const string MethodGetSimpleUserByLogonNameAsync = "GetSimpleUserByLogonNameAsync";
        private const string MethodGetSimpleUserByUniqueId = "GetSimpleUserByUniqueId";
        private const string MethodGetSimpleUserByUniqueIdAsync = "GetSimpleUserByUniqueIdAsync";
        private const string MethodQuerySkillsByUserID = "QuerySkillsByUserID";
        private const string MethodQuerySkillsByUserIDAsync = "QuerySkillsByUserIDAsync";
        private const string MethodQuerySkills = "QuerySkills";
        private const string MethodQuerySkillsAsync = "QuerySkillsAsync";
        private const string MethodSave = "Save";
        private const string MethodSaveAsync = "SaveAsync";
        private const string MethodSaveAll = "SaveAll";
        private const string MethodSaveAllAsync = "SaveAllAsync";
        private const string MethodQueryById = "QueryById";
        private const string MethodQueryByIdAsync = "QueryByIdAsync";
        private const string MethodQueryByName = "QueryByName";
        private const string MethodQueryByNameAsync = "QueryByNameAsync";
        private const string MethodQueryByEmail = "QueryByEmail";
        private const string MethodQueryByEmailAsync = "QueryByEmailAsync";
        private const string MethodQueryByDXUsers = "QueryByDXUsers";
        private const string MethodQueryByDXUsersAsync = "QueryByDXUsersAsync";
        private const string MethodAssignSkill = "AssignSkill";
        private const string MethodAssignSkillAsync = "AssignSkillAsync";
        private const string MethodAssignSkillSet = "AssignSkillSet";
        private const string MethodAssignSkillSetAsync = "AssignSkillSetAsync";
        private const string MethodAssignRateRule = "AssignRateRule";
        private const string MethodAssignRateRuleAsync = "AssignRateRuleAsync";
        private const string MethodCreateNew = "CreateNew";
        private const string MethodCreateNewAsync = "CreateNewAsync";
        private const string MethodOptomisticSave = "OptomisticSave";
        private const string MethodOptomisticSaveAsync = "OptomisticSaveAsync";

        #endregion

        private Type _usersClientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private UsersClient _usersClientInstance;
        private UsersClient _usersClientInstanceFixture;

        #region General Initializer : Class (UsersClient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UsersClient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _usersClientInstanceType = typeof(UsersClient);
            _usersClientInstanceFixture = this.Create<UsersClient>(true);
            _usersClientInstance = _usersClientInstanceFixture ?? this.Create<UsersClient>(false);
            CurrentInstance = _usersClientInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UsersClient) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="UsersClient" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_UsersClient_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<UsersClient>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<UsersClient>(Fixture);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfUsersClient = {  };
            Type [] methodUsersClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_usersClientInstanceType, methodUsersClientPrametersTypes, parametersOfUsersClient);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodUsersClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_usersClientInstanceType, Fixture, methodUsersClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            object[] parametersOfUsersClient = { endpointConfigurationName };
            var methodUsersClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_usersClientInstanceType, methodUsersClientPrametersTypes, parametersOfUsersClient);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodUsersClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_usersClientInstanceType, Fixture, methodUsersClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<string>();
            object[] parametersOfUsersClient = { endpointConfigurationName, remoteAddress };
            var methodUsersClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_usersClientInstanceType, methodUsersClientPrametersTypes, parametersOfUsersClient);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodUsersClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_usersClientInstanceType, Fixture, methodUsersClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = this.CreateType<string>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfUsersClient = { endpointConfigurationName, remoteAddress };
            var methodUsersClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_usersClientInstanceType, methodUsersClientPrametersTypes, parametersOfUsersClient);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodUsersClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_usersClientInstanceType, Fixture, methodUsersClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var binding = this.CreateType<System.ServiceModel.Channels.Binding>();
            var remoteAddress = this.CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfUsersClient = { binding, remoteAddress };
            var methodUsersClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_usersClientInstanceType, methodUsersClientPrametersTypes, parametersOfUsersClient);
        }

        #endregion

        #region General Constructor : Class (UsersClient) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="UsersClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_UsersClient_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodUsersClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_usersClientInstanceType, Fixture, methodUsersClientPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (QueryByAllSerialized) (Return Type : UplandIntegrations.TenroxUserService.QueryByAllSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByAllSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAllSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByAllSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByAllSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByAllSerialized, Fixture, methodQueryByAllSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : UplandIntegrations.TenroxUserService.QueryByUniqueIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByUniqueIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByUniqueIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByUniqueIdSerialized, Fixture, methodQueryByUniqueIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : UplandIntegrations.TenroxUserService.QueryByIdSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByIdSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByIdSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByIdSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByIdSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByIdSerialized, Fixture, methodQueryByIdSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : UplandIntegrations.TenroxUserService.QueryByNameSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByNameSerialized_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByNameSerialized) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByNameSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueryByNameSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByNameSerialized, Fixture, methodQueryByNameSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : UplandIntegrations.TenroxUserService.DeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_DeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_DeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodDeleteSerialized, Fixture, methodDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : UplandIntegrations.TenroxUserService.DeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_Delete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : UplandIntegrations.TenroxUserService.BulkDeleteSerializedResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_BulkDeleteSerialized_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDeleteSerialized) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_BulkDeleteSerialized_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeleteSerializedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodBulkDeleteSerialized, Fixture, methodBulkDeleteSerializedPrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : UplandIntegrations.TenroxUserService.BulkDeleteResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_BulkDelete_Method_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (BulkDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_BulkDelete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBulkDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodBulkDelete, Fixture, methodBulkDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAll) (Return Type : UplandIntegrations.TenroxUserService.User[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByAll_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByAll, Fixture, methodQueryByAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByUniqueId) (Return Type : UplandIntegrations.TenroxUserService.User) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByUniqueId_Method_Call_Internally(Type[] types)
        {
            var methodQueryByUniqueIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByUniqueId, Fixture, methodQueryByUniqueIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAllSimple) (Return Type : UplandIntegrations.TenroxUserService.UserSimple[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByAllSimple_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllSimplePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByAllSimple, Fixture, methodQueryByAllSimplePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByAllActiveSimple) (Return Type : UplandIntegrations.TenroxUserService.UserSimple[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByAllActiveSimple_Method_Call_Internally(Type[] types)
        {
            var methodQueryByAllActiveSimplePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByAllActiveSimple, Fixture, methodQueryByAllActiveSimplePrametersTypes);
        }

        #endregion

        #region Method Call : (FindSimpleUsersByName) (Return Type : UplandIntegrations.TenroxUserService.FindSimpleUsersByNameResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_FindSimpleUsersByName_Method_Call_Internally(Type[] types)
        {
            var methodFindSimpleUsersByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodFindSimpleUsersByName, Fixture, methodFindSimpleUsersByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (FindSimpleUsersByName) (Return Type : UplandIntegrations.TenroxUserService.UserSimple[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_FindSimpleUsersByName_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodFindSimpleUsersByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodFindSimpleUsersByName, Fixture, methodFindSimpleUsersByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (FindSimpleUsersByEmail) (Return Type : UplandIntegrations.TenroxUserService.FindSimpleUsersByEmailResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_FindSimpleUsersByEmail_Method_Call_Internally(Type[] types)
        {
            var methodFindSimpleUsersByEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodFindSimpleUsersByEmail, Fixture, methodFindSimpleUsersByEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (FindSimpleUsersByEmail) (Return Type : UplandIntegrations.TenroxUserService.UserSimple[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_FindSimpleUsersByEmail_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodFindSimpleUsersByEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodFindSimpleUsersByEmail, Fixture, methodFindSimpleUsersByEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllSimpleUsers) (Return Type : UplandIntegrations.TenroxUserService.GetAllSimpleUsersResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_GetAllSimpleUsers_Method_Call_Internally(Type[] types)
        {
            var methodGetAllSimpleUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodGetAllSimpleUsers, Fixture, methodGetAllSimpleUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllSimpleUsers) (Return Type : UplandIntegrations.TenroxUserService.UserSimple[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_GetAllSimpleUsers_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetAllSimpleUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodGetAllSimpleUsers, Fixture, methodGetAllSimpleUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSimpleUserByLogonName) (Return Type : UplandIntegrations.TenroxUserService.UserSimple[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_GetSimpleUserByLogonName_Method_Call_Internally(Type[] types)
        {
            var methodGetSimpleUserByLogonNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodGetSimpleUserByLogonName, Fixture, methodGetSimpleUserByLogonNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSimpleUserByUniqueId) (Return Type : UplandIntegrations.TenroxUserService.UserSimple[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_GetSimpleUserByUniqueId_Method_Call_Internally(Type[] types)
        {
            var methodGetSimpleUserByUniqueIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodGetSimpleUserByUniqueId, Fixture, methodGetSimpleUserByUniqueIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QuerySkillsByUserID) (Return Type : UplandIntegrations.TenroxUserService.Skill[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QuerySkillsByUserID_Method_Call_Internally(Type[] types)
        {
            var methodQuerySkillsByUserIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQuerySkillsByUserID, Fixture, methodQuerySkillsByUserIDPrametersTypes);
        }

        #endregion

        #region Method Call : (QuerySkills) (Return Type : UplandIntegrations.TenroxUserService.Skill[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QuerySkills_Method_Call_Internally(Type[] types)
        {
            var methodQuerySkillsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQuerySkills, Fixture, methodQuerySkillsPrametersTypes);
        }

        #endregion

        #region Method Call : (Save) (Return Type : UplandIntegrations.TenroxUserService.User) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_Save_Method_Call_Internally(Type[] types)
        {
            var methodSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodSave, Fixture, methodSavePrametersTypes);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : UplandIntegrations.TenroxUserService.User[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_SaveAll_Method_Call_Internally(Type[] types)
        {
            var methodSaveAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodSaveAll, Fixture, methodSaveAllPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryById) (Return Type : UplandIntegrations.TenroxUserService.User[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryById_Method_Call_Internally(Type[] types)
        {
            var methodQueryByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryById, Fixture, methodQueryByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByName) (Return Type : UplandIntegrations.TenroxUserService.User[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByName_Method_Call_Internally(Type[] types)
        {
            var methodQueryByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByName, Fixture, methodQueryByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByEmail) (Return Type : UplandIntegrations.TenroxUserService.User) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByEmail_Method_Call_Internally(Type[] types)
        {
            var methodQueryByEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByEmail, Fixture, methodQueryByEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryByDXUsers) (Return Type : UplandIntegrations.TenroxUserService.DXSelectedUser[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_QueryByDXUsers_Method_Call_Internally(Type[] types)
        {
            var methodQueryByDXUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodQueryByDXUsers, Fixture, methodQueryByDXUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (AssignSkill) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_AssignSkill_Method_Call_Internally(Type[] types)
        {
            var methodAssignSkillPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodAssignSkill, Fixture, methodAssignSkillPrametersTypes);
        }

        #endregion

        #region Method Call : (AssignSkillSet) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_AssignSkillSet_Method_Call_Internally(Type[] types)
        {
            var methodAssignSkillSetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodAssignSkillSet, Fixture, methodAssignSkillSetPrametersTypes);
        }

        #endregion

        #region Method Call : (AssignRateRule) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_AssignRateRule_Method_Call_Internally(Type[] types)
        {
            var methodAssignRateRulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodAssignRateRule, Fixture, methodAssignRateRulePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateNew) (Return Type : UplandIntegrations.TenroxUserService.User) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_CreateNew_Method_Call_Internally(Type[] types)
        {
            var methodCreateNewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodCreateNew, Fixture, methodCreateNewPrametersTypes);
        }

        #endregion

        #region Method Call : (OptomisticSave) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UsersClient_OptomisticSave_Method_Call_Internally(Type[] types)
        {
            var methodOptomisticSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersClientInstance, MethodOptomisticSave, Fixture, methodOptomisticSavePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}