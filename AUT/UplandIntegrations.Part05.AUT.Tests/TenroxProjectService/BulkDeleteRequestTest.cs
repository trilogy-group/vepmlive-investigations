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
using BulkDeleteRequest = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.BulkDeleteRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class BulkDeleteRequestTest : AbstractBaseSetupV3Test
    {
        public BulkDeleteRequestTest() : base(typeof(BulkDeleteRequest))
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

        #region General Initializer : Class (BulkDeleteRequest) Initializer

        #region Fields

        private const string Fieldp_token = "p_token";
        private const string Fieldp_intUniqueIds = "p_intUniqueIds";

        #endregion

        private Type _bulkDeleteRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private BulkDeleteRequest _bulkDeleteRequestInstance;
        private BulkDeleteRequest _bulkDeleteRequestInstanceFixture;

        #region General Initializer : Class (BulkDeleteRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BulkDeleteRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _bulkDeleteRequestInstanceType = typeof(BulkDeleteRequest);
            _bulkDeleteRequestInstanceFixture = this.Create<BulkDeleteRequest>(true);
            _bulkDeleteRequestInstance = _bulkDeleteRequestInstanceFixture ?? this.Create<BulkDeleteRequest>(false);
            CurrentInstance = _bulkDeleteRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (BulkDeleteRequest)

        #region General Initializer : Class (BulkDeleteRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="BulkDeleteRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_token)]
        [TestCase(Fieldp_intUniqueIds)]
        public void AUT_BulkDeleteRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_bulkDeleteRequestInstanceFixture, 
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
        ///     Class (<see cref="BulkDeleteRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_BulkDeleteRequest_Is_Instance_Present_Test()
        {
            // Assert
            _bulkDeleteRequestInstanceType.ShouldNotBeNull();
            _bulkDeleteRequestInstance.ShouldNotBeNull();
            _bulkDeleteRequestInstanceFixture.ShouldNotBeNull();
            _bulkDeleteRequestInstance.ShouldBeAssignableTo<BulkDeleteRequest>();
            _bulkDeleteRequestInstanceFixture.ShouldBeAssignableTo<BulkDeleteRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BulkDeleteRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BulkDeleteRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BulkDeleteRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _bulkDeleteRequestInstanceType.ShouldNotBeNull();
            _bulkDeleteRequestInstance.ShouldNotBeNull();
            _bulkDeleteRequestInstanceFixture.ShouldNotBeNull();
            _bulkDeleteRequestInstance.ShouldBeAssignableTo<BulkDeleteRequest>();
            _bulkDeleteRequestInstanceFixture.ShouldBeAssignableTo<BulkDeleteRequest>();
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_token = this.CreateType<UplandIntegrations.TenroxProjectService.UserToken>();
            var p_intUniqueIds = this.CreateType<int[]>();
            BulkDeleteRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new BulkDeleteRequest(p_token, p_intUniqueIds);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _bulkDeleteRequestInstance.ShouldNotBeNull();
            _bulkDeleteRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<BulkDeleteRequest>();
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_token = this.CreateType<UplandIntegrations.TenroxProjectService.UserToken>();
            var p_intUniqueIds = this.CreateType<int[]>();
            BulkDeleteRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new BulkDeleteRequest(p_token, p_intUniqueIds);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _bulkDeleteRequestInstance.ShouldNotBeNull();
            _bulkDeleteRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) instance created

        /// <summary>
        ///     Class (<see cref="BulkDeleteRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteRequest_Is_Created_Test()
        {
            // Assert
            _bulkDeleteRequestInstance.ShouldNotBeNull();
            _bulkDeleteRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="BulkDeleteRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_BulkDeleteRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<BulkDeleteRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="BulkDeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<BulkDeleteRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="BulkDeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfBulkDeleteRequest = {  };
            Type [] methodBulkDeleteRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_bulkDeleteRequestInstanceType, methodBulkDeleteRequestPrametersTypes, parametersOfBulkDeleteRequest);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="BulkDeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodBulkDeleteRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_bulkDeleteRequestInstanceType, Fixture, methodBulkDeleteRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="BulkDeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_token = this.CreateType<UplandIntegrations.TenroxProjectService.UserToken>();
            var p_intUniqueIds = this.CreateType<int[]>();
            object[] parametersOfBulkDeleteRequest = { p_token, p_intUniqueIds };
            var methodBulkDeleteRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxProjectService.UserToken), typeof(int[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_bulkDeleteRequestInstanceType, methodBulkDeleteRequestPrametersTypes, parametersOfBulkDeleteRequest);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="BulkDeleteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodBulkDeleteRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxProjectService.UserToken), typeof(int[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_bulkDeleteRequestInstanceType, Fixture, methodBulkDeleteRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}