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
using RunStoredProcedureScalarRequest = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureScalarRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureScalarRequestTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureScalarRequestTest() : base(typeof(RunStoredProcedureScalarRequest))
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

        #region General Initializer : Class (RunStoredProcedureScalarRequest) Initializer

        #region Fields

        private const string Fieldp_UserToken = "p_UserToken";
        private const string Fieldp_strStoredProcAlias = "p_strStoredProcAlias";
        private const string Fieldp_Parameters = "p_Parameters";

        #endregion

        private Type _runStoredProcedureScalarRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureScalarRequest _runStoredProcedureScalarRequestInstance;
        private RunStoredProcedureScalarRequest _runStoredProcedureScalarRequestInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureScalarRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureScalarRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureScalarRequestInstanceType = typeof(RunStoredProcedureScalarRequest);
            _runStoredProcedureScalarRequestInstanceFixture = this.Create<RunStoredProcedureScalarRequest>(true);
            _runStoredProcedureScalarRequestInstance = _runStoredProcedureScalarRequestInstanceFixture ?? this.Create<RunStoredProcedureScalarRequest>(false);
            CurrentInstance = _runStoredProcedureScalarRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunStoredProcedureScalarRequest)

        #region General Initializer : Class (RunStoredProcedureScalarRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureScalarRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_UserToken)]
        [TestCase(Fieldp_strStoredProcAlias)]
        [TestCase(Fieldp_Parameters)]
        public void AUT_RunStoredProcedureScalarRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runStoredProcedureScalarRequestInstanceFixture, 
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
        ///     Class (<see cref="RunStoredProcedureScalarRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureScalarRequest_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureScalarRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstance.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstance.ShouldBeAssignableTo<RunStoredProcedureScalarRequest>();
            _runStoredProcedureScalarRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureScalarRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureScalarRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureScalarRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureScalarRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureScalarRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstance.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstance.ShouldBeAssignableTo<RunStoredProcedureScalarRequest>();
            _runStoredProcedureScalarRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureScalarRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureScalarRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureScalarRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureScalarRequest(p_UserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstance.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<RunStoredProcedureScalarRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureScalarRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureScalarRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureScalarRequest(p_UserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstance.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) instance created

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureScalarRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureScalarRequest_Is_Created_Test()
        {
            // Assert
            _runStoredProcedureScalarRequestInstance.ShouldNotBeNull();
            _runStoredProcedureScalarRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureScalarRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_RunStoredProcedureScalarRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<RunStoredProcedureScalarRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="RunStoredProcedureScalarRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureScalarRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<RunStoredProcedureScalarRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureScalarRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureScalarRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfRunStoredProcedureScalarRequest = {  };
            Type [] methodRunStoredProcedureScalarRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureScalarRequestInstanceType, methodRunStoredProcedureScalarRequestPrametersTypes, parametersOfRunStoredProcedureScalarRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureScalarRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureScalarRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodRunStoredProcedureScalarRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureScalarRequestInstanceType, Fixture, methodRunStoredProcedureScalarRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureScalarRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureScalarRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_UserToken = this.CreateType<UplandIntegrations.TenroxDataService.UserToken>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            object[] parametersOfRunStoredProcedureScalarRequest = { p_UserToken, p_strStoredProcAlias, p_Parameters };
            var methodRunStoredProcedureScalarRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxDataService.UserToken), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureScalarRequestInstanceType, methodRunStoredProcedureScalarRequestPrametersTypes, parametersOfRunStoredProcedureScalarRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureScalarRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureScalarRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureScalarRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodRunStoredProcedureScalarRequestPrametersTypes = new Type[] { typeof(UplandIntegrations.TenroxDataService.UserToken), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureScalarRequestInstanceType, Fixture, methodRunStoredProcedureScalarRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}