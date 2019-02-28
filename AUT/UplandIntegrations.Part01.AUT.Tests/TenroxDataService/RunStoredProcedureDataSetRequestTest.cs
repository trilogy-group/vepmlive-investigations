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
using RunStoredProcedureDataSetRequest = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureDataSetRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureDataSetRequestTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureDataSetRequestTest() : base(typeof(RunStoredProcedureDataSetRequest))
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

        #region General Initializer : Class (RunStoredProcedureDataSetRequest) Initializer

        #region Fields

        private const string Fieldp_UserToken = "p_UserToken";
        private const string Fieldp_strStoredProcAlias = "p_strStoredProcAlias";
        private const string Fieldp_Parameters = "p_Parameters";

        #endregion

        private Type _runStoredProcedureDataSetRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureDataSetRequest _runStoredProcedureDataSetRequestInstance;
        private RunStoredProcedureDataSetRequest _runStoredProcedureDataSetRequestInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureDataSetRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureDataSetRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureDataSetRequestInstanceType = typeof(RunStoredProcedureDataSetRequest);
            _runStoredProcedureDataSetRequestInstanceFixture = this.Create<RunStoredProcedureDataSetRequest>(true);
            _runStoredProcedureDataSetRequestInstance = _runStoredProcedureDataSetRequestInstanceFixture ?? this.Create<RunStoredProcedureDataSetRequest>(false);
            CurrentInstance = _runStoredProcedureDataSetRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunStoredProcedureDataSetRequest)

        #region General Initializer : Class (RunStoredProcedureDataSetRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureDataSetRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_UserToken)]
        [TestCase(Fieldp_strStoredProcAlias)]
        [TestCase(Fieldp_Parameters)]
        public void AUT_RunStoredProcedureDataSetRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runStoredProcedureDataSetRequestInstanceFixture, 
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
        ///     Class (<see cref="RunStoredProcedureDataSetRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureDataSetRequest_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureDataSetRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstance.ShouldBeAssignableTo<RunStoredProcedureDataSetRequest>();
            _runStoredProcedureDataSetRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureDataSetRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureDataSetRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureDataSetRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureDataSetRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstance.ShouldBeAssignableTo<RunStoredProcedureDataSetRequest>();
            _runStoredProcedureDataSetRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureDataSetRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureDataSetRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureDataSetRequest(p_UserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<RunStoredProcedureDataSetRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureDataSetRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureDataSetRequest(p_UserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) instance created

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureDataSetRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetRequest_Is_Created_Test()
        {
            // Assert
            _runStoredProcedureDataSetRequestInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureDataSetRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_RunStoredProcedureDataSetRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<RunStoredProcedureDataSetRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="RunStoredProcedureDataSetRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<RunStoredProcedureDataSetRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureDataSetRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfRunStoredProcedureDataSetRequest = {  };
            Type [] methodRunStoredProcedureDataSetRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureDataSetRequestInstanceType, methodRunStoredProcedureDataSetRequestPrametersTypes, parametersOfRunStoredProcedureDataSetRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureDataSetRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodRunStoredProcedureDataSetRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureDataSetRequestInstanceType, Fixture, methodRunStoredProcedureDataSetRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureDataSetRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            object[] parametersOfRunStoredProcedureDataSetRequest = { p_UserToken, p_strStoredProcAlias, p_Parameters };
            var methodRunStoredProcedureDataSetRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxDataService.UserToken), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureDataSetRequestInstanceType, methodRunStoredProcedureDataSetRequestPrametersTypes, parametersOfRunStoredProcedureDataSetRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureDataSetRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodRunStoredProcedureDataSetRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxDataService.UserToken), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureDataSetRequestInstanceType, Fixture, methodRunStoredProcedureDataSetRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}