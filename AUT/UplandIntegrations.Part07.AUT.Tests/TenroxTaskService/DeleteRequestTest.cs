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
using UplandIntegrations.TenroxTaskService;
using DeleteRequest = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.DeleteRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeleteRequestTest : AbstractBaseSetupV3Test
    {
        public DeleteRequestTest() : base(typeof(DeleteRequest))
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

        #region General Initializer : Class (DeleteRequest) Initializer

        #region Fields

        private const string Fieldp_token = "p_token";
        private const string Fieldp_intUniqueId = "p_intUniqueId";

        #endregion

        private Type _deleteRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private DeleteRequest _deleteRequestInstance;
        private DeleteRequest _deleteRequestInstanceFixture;

        #region General Initializer : Class (DeleteRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeleteRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deleteRequestInstanceType = typeof(DeleteRequest);
            _deleteRequestInstanceFixture = this.Create<DeleteRequest>(true);
            _deleteRequestInstance = _deleteRequestInstanceFixture ?? this.Create<DeleteRequest>(false);
            CurrentInstance = _deleteRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DeleteRequest)

        #region General Initializer : Class (DeleteRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DeleteRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_token)]
        [TestCase(Fieldp_intUniqueId)]
        public void AUT_DeleteRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_deleteRequestInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DeleteRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DeleteRequest_Is_Instance_Present_Test()
        {
            // Assert
            _deleteRequestInstanceType.ShouldNotBeNull();
            _deleteRequestInstance.ShouldNotBeNull();
            _deleteRequestInstanceFixture.ShouldNotBeNull();
            _deleteRequestInstance.ShouldBeAssignableTo<DeleteRequest>();
            _deleteRequestInstanceFixture.ShouldBeAssignableTo<DeleteRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeleteRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DeleteRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeleteRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deleteRequestInstanceType.ShouldNotBeNull();
            _deleteRequestInstance.ShouldNotBeNull();
            _deleteRequestInstanceFixture.ShouldNotBeNull();
            _deleteRequestInstance.ShouldBeAssignableTo<DeleteRequest>();
            _deleteRequestInstanceFixture.ShouldBeAssignableTo<DeleteRequest>();
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_token = this.CreateType<UplandIntegrations.TenroxTaskService.UserToken>();
            var p_intUniqueId = this.CreateType<int>();
            DeleteRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DeleteRequest(p_token, p_intUniqueId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _deleteRequestInstance.ShouldNotBeNull();
            _deleteRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<DeleteRequest>();
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_token = this.CreateType<UplandIntegrations.TenroxTaskService.UserToken>();
            var p_intUniqueId = this.CreateType<int>();
            DeleteRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DeleteRequest(p_token, p_intUniqueId);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _deleteRequestInstance.ShouldNotBeNull();
            _deleteRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) instance created

        /// <summary>
        ///     Class (<see cref="DeleteRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteRequest_Is_Created_Test()
        {
            // Assert
            _deleteRequestInstance.ShouldNotBeNull();
            _deleteRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="DeleteRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_DeleteRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<DeleteRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="DeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<DeleteRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfDeleteRequest = {  };
            Type [] methodDeleteRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_deleteRequestInstanceType, methodDeleteRequestPrametersTypes, parametersOfDeleteRequest);
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodDeleteRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_deleteRequestInstanceType, Fixture, methodDeleteRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_token = this.CreateType<UplandIntegrations.TenroxTaskService.UserToken>();
            var p_intUniqueId = this.CreateType<int>();
            object[] parametersOfDeleteRequest = { p_token, p_intUniqueId };
            var methodDeleteRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxTaskService.UserToken), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_deleteRequestInstanceType, methodDeleteRequestPrametersTypes, parametersOfDeleteRequest);
        }

        #endregion

        #region General Constructor : Class (DeleteRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DeleteRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodDeleteRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxTaskService.UserToken), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_deleteRequestInstanceType, Fixture, methodDeleteRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}