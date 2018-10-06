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
using RunStoredProcedureResponse = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureResponseTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureResponseTest() : base(typeof(RunStoredProcedureResponse))
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

        #region General Initializer : Class (RunStoredProcedureResponse) Initializer

        #region Fields

        private const string FieldRunStoredProcedureResult = "RunStoredProcedureResult";

        #endregion

        private Type _runStoredProcedureResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureResponse _runStoredProcedureResponseInstance;
        private RunStoredProcedureResponse _runStoredProcedureResponseInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureResponseInstanceType = typeof(RunStoredProcedureResponse);
            _runStoredProcedureResponseInstanceFixture = this.Create<RunStoredProcedureResponse>(true);
            _runStoredProcedureResponseInstance = _runStoredProcedureResponseInstanceFixture ?? this.Create<RunStoredProcedureResponse>(false);
            CurrentInstance = _runStoredProcedureResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunStoredProcedureResponse)

        #region General Initializer : Class (RunStoredProcedureResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldRunStoredProcedureResult)]
        public void AUT_RunStoredProcedureResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runStoredProcedureResponseInstanceFixture, 
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
        ///     Class (<see cref="RunStoredProcedureResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureResponse_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureResponseInstance.ShouldNotBeNull();
            _runStoredProcedureResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureResponseInstance.ShouldBeAssignableTo<RunStoredProcedureResponse>();
            _runStoredProcedureResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureResponseInstance.ShouldNotBeNull();
            _runStoredProcedureResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureResponseInstance.ShouldBeAssignableTo<RunStoredProcedureResponse>();
            _runStoredProcedureResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureResponse>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var RunStoredProcedureResult = this.CreateType<System.Data.DataTable>();
            RunStoredProcedureResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureResponse(RunStoredProcedureResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureResponseInstance.ShouldNotBeNull();
            _runStoredProcedureResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<RunStoredProcedureResponse>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var RunStoredProcedureResult = this.CreateType<System.Data.DataTable>();
            RunStoredProcedureResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureResponse(RunStoredProcedureResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureResponseInstance.ShouldNotBeNull();
            _runStoredProcedureResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) instance created

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureResponse_Is_Created_Test()
        {
            // Assert
            _runStoredProcedureResponseInstance.ShouldNotBeNull();
            _runStoredProcedureResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_RunStoredProcedureResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<RunStoredProcedureResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="RunStoredProcedureResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<RunStoredProcedureResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfRunStoredProcedureResponse = {  };
            Type [] methodRunStoredProcedureResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureResponseInstanceType, methodRunStoredProcedureResponsePrametersTypes, parametersOfRunStoredProcedureResponse);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodRunStoredProcedureResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureResponseInstanceType, Fixture, methodRunStoredProcedureResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var RunStoredProcedureResult = this.CreateType<System.Data.DataTable>();
            object[] parametersOfRunStoredProcedureResponse = { RunStoredProcedureResult };
            var methodRunStoredProcedureResponsePrametersTypes = new Type[] { typeof(System.Data.DataTable) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureResponseInstanceType, methodRunStoredProcedureResponsePrametersTypes, parametersOfRunStoredProcedureResponse);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodRunStoredProcedureResponsePrametersTypes = new Type[] { typeof(System.Data.DataTable) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureResponseInstanceType, Fixture, methodRunStoredProcedureResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}