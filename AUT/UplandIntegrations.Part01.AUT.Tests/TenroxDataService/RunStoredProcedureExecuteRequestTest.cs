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
using RunStoredProcedureExecuteRequest = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureExecuteRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureExecuteRequestTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureExecuteRequestTest() : base(typeof(RunStoredProcedureExecuteRequest))
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

        #region General Initializer : Class (RunStoredProcedureExecuteRequest) Initializer

        #region Fields

        private const string Fieldp_UserToken = "p_UserToken";
        private const string Fieldp_strStoredProcAlias = "p_strStoredProcAlias";
        private const string Fieldp_Parameters = "p_Parameters";

        #endregion

        private Type _runStoredProcedureExecuteRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureExecuteRequest _runStoredProcedureExecuteRequestInstance;
        private RunStoredProcedureExecuteRequest _runStoredProcedureExecuteRequestInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureExecuteRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureExecuteRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureExecuteRequestInstanceType = typeof(RunStoredProcedureExecuteRequest);
            _runStoredProcedureExecuteRequestInstanceFixture = this.Create<RunStoredProcedureExecuteRequest>(true);
            _runStoredProcedureExecuteRequestInstance = _runStoredProcedureExecuteRequestInstanceFixture ?? this.Create<RunStoredProcedureExecuteRequest>(false);
            CurrentInstance = _runStoredProcedureExecuteRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunStoredProcedureExecuteRequest)

        #region General Initializer : Class (RunStoredProcedureExecuteRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureExecuteRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_UserToken)]
        [TestCase(Fieldp_strStoredProcAlias)]
        [TestCase(Fieldp_Parameters)]
        public void AUT_RunStoredProcedureExecuteRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runStoredProcedureExecuteRequestInstanceFixture, 
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
        ///     Class (<see cref="RunStoredProcedureExecuteRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureExecuteRequest_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureExecuteRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstance.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstance.ShouldBeAssignableTo<RunStoredProcedureExecuteRequest>();
            _runStoredProcedureExecuteRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureExecuteRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureExecuteRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureExecuteRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureExecuteRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstance.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstance.ShouldBeAssignableTo<RunStoredProcedureExecuteRequest>();
            _runStoredProcedureExecuteRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureExecuteRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureExecuteRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureExecuteRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureExecuteRequest(p_UserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstance.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<RunStoredProcedureExecuteRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureExecuteRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureExecuteRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureExecuteRequest(p_UserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstance.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) instance created

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureExecuteRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureExecuteRequest_Is_Created_Test()
        {
            // Assert
            _runStoredProcedureExecuteRequestInstance.ShouldNotBeNull();
            _runStoredProcedureExecuteRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureExecuteRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_RunStoredProcedureExecuteRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<RunStoredProcedureExecuteRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="RunStoredProcedureExecuteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureExecuteRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<RunStoredProcedureExecuteRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureExecuteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureExecuteRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfRunStoredProcedureExecuteRequest = {  };
            Type [] methodRunStoredProcedureExecuteRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureExecuteRequestInstanceType, methodRunStoredProcedureExecuteRequestPrametersTypes, parametersOfRunStoredProcedureExecuteRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureExecuteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureExecuteRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodRunStoredProcedureExecuteRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureExecuteRequestInstanceType, Fixture, methodRunStoredProcedureExecuteRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureExecuteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureExecuteRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            object[] parametersOfRunStoredProcedureExecuteRequest = { p_UserToken, p_strStoredProcAlias, p_Parameters };
            var methodRunStoredProcedureExecuteRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxDataService.UserToken), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureExecuteRequestInstanceType, methodRunStoredProcedureExecuteRequestPrametersTypes, parametersOfRunStoredProcedureExecuteRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureExecuteRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureExecuteRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureExecuteRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodRunStoredProcedureExecuteRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxDataService.UserToken), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureExecuteRequestInstanceType, Fixture, methodRunStoredProcedureExecuteRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}