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
using BulkDeleteSerializedRequest = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.BulkDeleteSerializedRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class BulkDeleteSerializedRequestTest : AbstractBaseSetupV3Test
    {
        public BulkDeleteSerializedRequestTest() : base(typeof(BulkDeleteSerializedRequest))
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

        #region General Initializer : Class (BulkDeleteSerializedRequest) Initializer

        #region Fields

        private const string Fieldp_strToken = "p_strToken";
        private const string Fieldp_intUniqueIds = "p_intUniqueIds";

        #endregion

        private Type _bulkDeleteSerializedRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private BulkDeleteSerializedRequest _bulkDeleteSerializedRequestInstance;
        private BulkDeleteSerializedRequest _bulkDeleteSerializedRequestInstanceFixture;

        #region General Initializer : Class (BulkDeleteSerializedRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BulkDeleteSerializedRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _bulkDeleteSerializedRequestInstanceType = typeof(BulkDeleteSerializedRequest);
            _bulkDeleteSerializedRequestInstanceFixture = this.Create<BulkDeleteSerializedRequest>(true);
            _bulkDeleteSerializedRequestInstance = _bulkDeleteSerializedRequestInstanceFixture ?? this.Create<BulkDeleteSerializedRequest>(false);
            CurrentInstance = _bulkDeleteSerializedRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (BulkDeleteSerializedRequest)

        #region General Initializer : Class (BulkDeleteSerializedRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="BulkDeleteSerializedRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_strToken)]
        [TestCase(Fieldp_intUniqueIds)]
        public void AUT_BulkDeleteSerializedRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_bulkDeleteSerializedRequestInstanceFixture, 
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
        ///     Class (<see cref="BulkDeleteSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_BulkDeleteSerializedRequest_Is_Instance_Present_Test()
        {
            // Assert
            _bulkDeleteSerializedRequestInstanceType.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstance.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstanceFixture.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstance.ShouldBeAssignableTo<BulkDeleteSerializedRequest>();
            _bulkDeleteSerializedRequestInstanceFixture.ShouldBeAssignableTo<BulkDeleteSerializedRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BulkDeleteSerializedRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BulkDeleteSerializedRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BulkDeleteSerializedRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _bulkDeleteSerializedRequestInstanceType.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstance.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstanceFixture.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstance.ShouldBeAssignableTo<BulkDeleteSerializedRequest>();
            _bulkDeleteSerializedRequestInstanceFixture.ShouldBeAssignableTo<BulkDeleteSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteSerializedRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueIds = this.CreateType<int[]>();
            BulkDeleteSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new BulkDeleteSerializedRequest(p_strToken, p_intUniqueIds);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstance.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<BulkDeleteSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteSerializedRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueIds = this.CreateType<int[]>();
            BulkDeleteSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new BulkDeleteSerializedRequest(p_strToken, p_intUniqueIds);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstance.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) instance created

        /// <summary>
        ///     Class (<see cref="BulkDeleteSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteSerializedRequest_Is_Created_Test()
        {
            // Assert
            _bulkDeleteSerializedRequestInstance.ShouldNotBeNull();
            _bulkDeleteSerializedRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="BulkDeleteSerializedRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_BulkDeleteSerializedRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<BulkDeleteSerializedRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="BulkDeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteSerializedRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<BulkDeleteSerializedRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="BulkDeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteSerializedRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfBulkDeleteSerializedRequest = {  };
            Type [] methodBulkDeleteSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_bulkDeleteSerializedRequestInstanceType, methodBulkDeleteSerializedRequestPrametersTypes, parametersOfBulkDeleteSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="BulkDeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteSerializedRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodBulkDeleteSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_bulkDeleteSerializedRequestInstanceType, Fixture, methodBulkDeleteSerializedRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="BulkDeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteSerializedRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_strToken = this.CreateType<string>();
            var p_intUniqueIds = this.CreateType<int[]>();
            object[] parametersOfBulkDeleteSerializedRequest = { p_strToken, p_intUniqueIds };
            var methodBulkDeleteSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(int[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_bulkDeleteSerializedRequestInstanceType, methodBulkDeleteSerializedRequestPrametersTypes, parametersOfBulkDeleteSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (BulkDeleteSerializedRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="BulkDeleteSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_BulkDeleteSerializedRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodBulkDeleteSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(int[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_bulkDeleteSerializedRequestInstanceType, Fixture, methodBulkDeleteSerializedRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}