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
using RunStoredProcedureDataSetResponse = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureDataSetResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureDataSetResponseTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureDataSetResponseTest() : base(typeof(RunStoredProcedureDataSetResponse))
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

        #region General Initializer : Class (RunStoredProcedureDataSetResponse) Initializer

        #region Fields

        private const string FieldRunStoredProcedureDataSetResult = "RunStoredProcedureDataSetResult";

        #endregion

        private Type _runStoredProcedureDataSetResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureDataSetResponse _runStoredProcedureDataSetResponseInstance;
        private RunStoredProcedureDataSetResponse _runStoredProcedureDataSetResponseInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureDataSetResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureDataSetResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureDataSetResponseInstanceType = typeof(RunStoredProcedureDataSetResponse);
            _runStoredProcedureDataSetResponseInstanceFixture = this.Create<RunStoredProcedureDataSetResponse>(true);
            _runStoredProcedureDataSetResponseInstance = _runStoredProcedureDataSetResponseInstanceFixture ?? this.Create<RunStoredProcedureDataSetResponse>(false);
            CurrentInstance = _runStoredProcedureDataSetResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunStoredProcedureDataSetResponse)

        #region General Initializer : Class (RunStoredProcedureDataSetResponse) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureDataSetResponse" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldRunStoredProcedureDataSetResult)]
        public void AUT_RunStoredProcedureDataSetResponse_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runStoredProcedureDataSetResponseInstanceFixture, 
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
        ///     Class (<see cref="RunStoredProcedureDataSetResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureDataSetResponse_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureDataSetResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstance.ShouldBeAssignableTo<RunStoredProcedureDataSetResponse>();
            _runStoredProcedureDataSetResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureDataSetResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureDataSetResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureDataSetResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureDataSetResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstance.ShouldBeAssignableTo<RunStoredProcedureDataSetResponse>();
            _runStoredProcedureDataSetResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureDataSetResponse>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetResponse_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var RunStoredProcedureDataSetResult = this.CreateType<System.Data.DataSet>();
            RunStoredProcedureDataSetResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureDataSetResponse(RunStoredProcedureDataSetResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<RunStoredProcedureDataSetResponse>();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetResponse_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var RunStoredProcedureDataSetResult = this.CreateType<System.Data.DataSet>();
            RunStoredProcedureDataSetResponse instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new RunStoredProcedureDataSetResponse(RunStoredProcedureDataSetResult);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) instance created

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureDataSetResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetResponse_Is_Created_Test()
        {
            // Assert
            _runStoredProcedureDataSetResponseInstance.ShouldNotBeNull();
            _runStoredProcedureDataSetResponseInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureDataSetResponse" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_RunStoredProcedureDataSetResponse_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<RunStoredProcedureDataSetResponse>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="RunStoredProcedureDataSetResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetResponse_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<RunStoredProcedureDataSetResponse>(Fixture);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureDataSetResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetResponse_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfRunStoredProcedureDataSetResponse = {  };
            Type [] methodRunStoredProcedureDataSetResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureDataSetResponseInstanceType, methodRunStoredProcedureDataSetResponsePrametersTypes, parametersOfRunStoredProcedureDataSetResponse);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureDataSetResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetResponse_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodRunStoredProcedureDataSetResponsePrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureDataSetResponseInstanceType, Fixture, methodRunStoredProcedureDataSetResponsePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureDataSetResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetResponse_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var RunStoredProcedureDataSetResult = this.CreateType<System.Data.DataSet>();
            object[] parametersOfRunStoredProcedureDataSetResponse = { RunStoredProcedureDataSetResult };
            var methodRunStoredProcedureDataSetResponsePrametersTypes = new Type[] { typeof(System.Data.DataSet) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_runStoredProcedureDataSetResponseInstanceType, methodRunStoredProcedureDataSetResponsePrametersTypes, parametersOfRunStoredProcedureDataSetResponse);
        }

        #endregion

        #region General Constructor : Class (RunStoredProcedureDataSetResponse) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="RunStoredProcedureDataSetResponse" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RunStoredProcedureDataSetResponse_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodRunStoredProcedureDataSetResponsePrametersTypes = new Type[] { typeof(System.Data.DataSet) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_runStoredProcedureDataSetResponseInstanceType, Fixture, methodRunStoredProcedureDataSetResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}