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
using RunStoredProcedureSerializedRequest = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureSerializedRequest" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureSerializedRequestTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureSerializedRequestTest() : base(typeof(RunStoredProcedureSerializedRequest))
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

        #region General Initializer : Class (RunStoredProcedureSerializedRequest) Initializer

        #region Fields

        private const string Fieldp_strUserToken = "p_strUserToken";
        private const string Fieldp_strStoredProcAlias = "p_strStoredProcAlias";
        private const string Fieldp_Parameters = "p_Parameters";

        #endregion

        private Type _runStoredProcedureSerializedRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureSerializedRequest _runStoredProcedureSerializedRequestInstance;
        private RunStoredProcedureSerializedRequest _runStoredProcedureSerializedRequestInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureSerializedRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureSerializedRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureSerializedRequestInstanceType = typeof(RunStoredProcedureSerializedRequest);
            _runStoredProcedureSerializedRequestInstanceFixture = this.Create<RunStoredProcedureSerializedRequest>(true);
            _runStoredProcedureSerializedRequestInstance = _runStoredProcedureSerializedRequestInstanceFixture ?? this.Create<RunStoredProcedureSerializedRequest>(false);
            CurrentInstance = _runStoredProcedureSerializedRequestInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunStoredProcedureSerializedRequest)

        #region General Initializer : Class (RunStoredProcedureSerializedRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureSerializedRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldp_strUserToken)]
        [TestCase(Fieldp_strStoredProcAlias)]
        [TestCase(Fieldp_Parameters)]
        public void AUT_RunStoredProcedureSerializedRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runStoredProcedureSerializedRequestInstanceFixture, 
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
        ///     Class (<see cref="RunStoredProcedureSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureSerializedRequest_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureSerializedRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstance.ShouldBeAssignableTo<RunStoredProcedureSerializedRequest>();
            _runStoredProcedureSerializedRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureSerializedRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureSerializedRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureSerializedRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureSerializedRequestInstanceType.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstance.ShouldBeAssignableTo<RunStoredProcedureSerializedRequest>();
            _runStoredProcedureSerializedRequestInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedRequest_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var p_strUserToken = this.CreateType<string>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureSerializedRequest(p_strUserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<RunStoredProcedureSerializedRequest>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedRequest_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var p_strUserToken = this.CreateType<string>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            RunStoredProcedureSerializedRequest instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureSerializedRequest(p_strUserToken, p_strStoredProcAlias, p_Parameters);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) instance created

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureSerializedRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedRequest_Is_Created_Test()
        {
            // Assert
            _runStoredProcedureSerializedRequestInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedRequestInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureSerializedRequest" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_RunStoredProcedureSerializedRequest_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<RunStoredProcedureSerializedRequest>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="RunStoredProcedureSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedRequest_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<RunStoredProcedureSerializedRequest>(Fixture);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedRequest_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfRunStoredProcedureSerializedRequest = {  };
            Type [] methodRunStoredProcedureSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureSerializedRequestInstanceType, methodRunStoredProcedureSerializedRequestPrametersTypes, parametersOfRunStoredProcedureSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedRequest_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodRunStoredProcedureSerializedRequestPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureSerializedRequestInstanceType, Fixture, methodRunStoredProcedureSerializedRequestPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedRequest_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var p_strUserToken = this.CreateType<string>();
            var p_strStoredProcAlias = this.CreateType<string>();
            var p_Parameters = this.CreateType<object[]>();
            object[] parametersOfRunStoredProcedureSerializedRequest = { p_strUserToken, p_strStoredProcAlias, p_Parameters };
            var methodRunStoredProcedureSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureSerializedRequestInstanceType, methodRunStoredProcedureSerializedRequestPrametersTypes, parametersOfRunStoredProcedureSerializedRequest);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedRequest) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureSerializedRequest" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedRequest_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodRunStoredProcedureSerializedRequestPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(object[]) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureSerializedRequestInstanceType, Fixture, methodRunStoredProcedureSerializedRequestPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}