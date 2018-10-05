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
using RunStoredProcedureExecuteResponse = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureExecuteResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureExecuteResponseTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureExecuteResponseTest() : base(typeof(RunStoredProcedureExecuteResponse))
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

        #region General Initializer : Class (RunStoredProcedureExecuteResponse) Initializer

        private Type _runStoredProcedureExecuteResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureExecuteResponse _runStoredProcedureExecuteResponseInstance;
        private RunStoredProcedureExecuteResponse _runStoredProcedureExecuteResponseInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureExecuteResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureExecuteResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureExecuteResponseInstanceType = typeof(RunStoredProcedureExecuteResponse);
            _runStoredProcedureExecuteResponseInstanceFixture = this.Create<RunStoredProcedureExecuteResponse>(true);
            _runStoredProcedureExecuteResponseInstance = _runStoredProcedureExecuteResponseInstanceFixture ?? this.Create<RunStoredProcedureExecuteResponse>(false);
            CurrentInstance = _runStoredProcedureExecuteResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureExecuteResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureExecuteResponse_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureExecuteResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureExecuteResponseInstance.ShouldNotBeNull();
            _runStoredProcedureExecuteResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureExecuteResponseInstance.ShouldBeAssignableTo<RunStoredProcedureExecuteResponse>();
            _runStoredProcedureExecuteResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureExecuteResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureExecuteResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureExecuteResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureExecuteResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureExecuteResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureExecuteResponseInstance.ShouldNotBeNull();
            _runStoredProcedureExecuteResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureExecuteResponseInstance.ShouldBeAssignableTo<RunStoredProcedureExecuteResponse>();
            _runStoredProcedureExecuteResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureExecuteResponse>();
        }

        #endregion

        #endregion

        #endregion
    }
}