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
using RunStoredProcedureSerializedResponse = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureSerializedResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureSerializedResponseTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureSerializedResponseTest() : base(typeof(RunStoredProcedureSerializedResponse))
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

        #region General Initializer : Class (RunStoredProcedureSerializedResponse) Initializer

        #region Fields

        private const string FieldRunStoredProcedureSerializedResult = "RunStoredProcedureSerializedResult";

        #endregion

        private Type _runStoredProcedureSerializedResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureSerializedResponse _runStoredProcedureSerializedResponseInstance;
        private RunStoredProcedureSerializedResponse _runStoredProcedureSerializedResponseInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureSerializedResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureSerializedResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureSerializedResponseInstanceType = typeof(RunStoredProcedureSerializedResponse);
            _runStoredProcedureSerializedResponseInstanceFixture = this.Create<RunStoredProcedureSerializedResponse>(true);
            _runStoredProcedureSerializedResponseInstance = _runStoredProcedureSerializedResponseInstanceFixture ?? this.Create<RunStoredProcedureSerializedResponse>(false);
            CurrentInstance = _runStoredProcedureSerializedResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunStoredProcedureSerializedResponse)

        #region General Initializer : Class (RunStoredProcedureSerializedResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureSerializedResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldRunStoredProcedureSerializedResult)]
        public void AUT_RunStoredProcedureSerializedResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runStoredProcedureSerializedResponseInstanceFixture, 
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
        ///     Class (<see cref="RunStoredProcedureSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureSerializedResponse_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureSerializedResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstance.ShouldBeAssignableTo<RunStoredProcedureSerializedResponse>();
            _runStoredProcedureSerializedResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureSerializedResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureSerializedResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureSerializedResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureSerializedResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstance.ShouldBeAssignableTo<RunStoredProcedureSerializedResponse>();
            _runStoredProcedureSerializedResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var RunStoredProcedureSerializedResult = this.CreateType<System.Data.DataTable>();
            RunStoredProcedureSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureSerializedResponse(RunStoredProcedureSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<RunStoredProcedureSerializedResponse>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var RunStoredProcedureSerializedResult = this.CreateType<System.Data.DataTable>();
            RunStoredProcedureSerializedResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureSerializedResponse(RunStoredProcedureSerializedResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) instance created

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedResponse_Is_Created_Test()
        {
            // Assert
            _runStoredProcedureSerializedResponseInstance.ShouldNotBeNull();
            _runStoredProcedureSerializedResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureSerializedResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_RunStoredProcedureSerializedResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<RunStoredProcedureSerializedResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="RunStoredProcedureSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<RunStoredProcedureSerializedResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfRunStoredProcedureSerializedResponse = {  };
            Type [] methodRunStoredProcedureSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureSerializedResponseInstanceType, methodRunStoredProcedureSerializedResponsePrametersTypes, parametersOfRunStoredProcedureSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodRunStoredProcedureSerializedResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureSerializedResponseInstanceType, Fixture, methodRunStoredProcedureSerializedResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var RunStoredProcedureSerializedResult = this.CreateType<System.Data.DataTable>();
            object[] parametersOfRunStoredProcedureSerializedResponse = { RunStoredProcedureSerializedResult };
            var methodRunStoredProcedureSerializedResponsePrametersTypes = new Type[] { typeof(System.Data.DataTable) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureSerializedResponseInstanceType, methodRunStoredProcedureSerializedResponsePrametersTypes, parametersOfRunStoredProcedureSerializedResponse);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureSerializedResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureSerializedResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureSerializedResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodRunStoredProcedureSerializedResponsePrametersTypes = new Type[] { typeof(System.Data.DataTable) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureSerializedResponseInstanceType, Fixture, methodRunStoredProcedureSerializedResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}