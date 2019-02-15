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
using RunStoredProcedureRequest = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureRequestTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureRequestTest() : base(typeof(RunStoredProcedureRequest))
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

        #region General Initializer : Class (RunStoredProcedureRequest) Initializer

        #region Fields

        private const string Fieldp_UserToken = "p_UserToken";
        private const string Fieldp_strStoredProcAlias = "p_strStoredProcAlias";
        private const string Fieldp_Parameters = "p_Parameters";

        #endregion

        private Type _runStoredProcedureRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureRequest _runStoredProcedureRequestInstance;
        private RunStoredProcedureRequest _runStoredProcedureRequestInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureRequestInstanceType = typeof(RunStoredProcedureRequest);
            _runStoredProcedureRequestInstanceFixture = this.Create<RunStoredProcedureRequest>(true);
            _runStoredProcedureRequestInstance = _runStoredProcedureRequestInstanceFixture ?? this.Create<RunStoredProcedureRequest>(false);
            CurrentInstance = _runStoredProcedureRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunStoredProcedureRequest)

        #region General Initializer : Class (RunStoredProcedureRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_UserToken)]
        [TestCase(Fieldp_strStoredProcAlias)]
        [TestCase(Fieldp_Parameters)]
        public void AUT_RunStoredProcedureRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runStoredProcedureRequestInstanceFixture, 
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
        ///     Class (<see cref="RunStoredProcedureRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureRequest_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureRequestInstance.ShouldNotBeNull();
            _runStoredProcedureRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureRequestInstance.ShouldBeAssignableTo<RunStoredProcedureRequest>();
            _runStoredProcedureRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureRequestInstance.ShouldNotBeNull();
            _runStoredProcedureRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureRequestInstance.ShouldBeAssignableTo<RunStoredProcedureRequest>();
            _runStoredProcedureRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureRequest(p_UserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureRequestInstance.ShouldNotBeNull();
            _runStoredProcedureRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<RunStoredProcedureRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureRequest(p_UserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureRequestInstance.ShouldNotBeNull();
            _runStoredProcedureRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) instance created

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureRequest_Is_Created_Test()
        {
            // Assert
            _runStoredProcedureRequestInstance.ShouldNotBeNull();
            _runStoredProcedureRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_RunStoredProcedureRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<RunStoredProcedureRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="RunStoredProcedureRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<RunStoredProcedureRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfRunStoredProcedureRequest = {  };
            Type [] methodRunStoredProcedureRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureRequestInstanceType, methodRunStoredProcedureRequestPrametersTypes, parametersOfRunStoredProcedureRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodRunStoredProcedureRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureRequestInstanceType, Fixture, methodRunStoredProcedureRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            object[] parametersOfRunStoredProcedureRequest = { p_UserToken, p_strStoredProcAlias, p_Parameters };
            var methodRunStoredProcedureRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxDataService.UserToken), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureRequestInstanceType, methodRunStoredProcedureRequestPrametersTypes, parametersOfRunStoredProcedureRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodRunStoredProcedureRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxDataService.UserToken), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureRequestInstanceType, Fixture, methodRunStoredProcedureRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}