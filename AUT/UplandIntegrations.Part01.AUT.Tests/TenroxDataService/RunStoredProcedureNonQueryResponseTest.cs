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
using RunStoredProcedureNonQueryResponse = UplandIntegrations.TenroxDataService;

namespace UplandIntegrations.TenroxDataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxDataService.RunStoredProcedureNonQueryResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxDataService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunStoredProcedureNonQueryResponseTest : AbstractBaseSetupV3Test
    {
        public RunStoredProcedureNonQueryResponseTest() : base(typeof(RunStoredProcedureNonQueryResponse))
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

        #region General Initializer : Class (RunStoredProcedureNonQueryResponse) Initializer

        private Type _runStoredProcedureNonQueryResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private RunStoredProcedureNonQueryResponse _runStoredProcedureNonQueryResponseInstance;
        private RunStoredProcedureNonQueryResponse _runStoredProcedureNonQueryResponseInstanceFixture;

        #region General Initializer : Class (RunStoredProcedureNonQueryResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunStoredProcedureNonQueryResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runStoredProcedureNonQueryResponseInstanceType = typeof(RunStoredProcedureNonQueryResponse);
            _runStoredProcedureNonQueryResponseInstanceFixture = this.Create<RunStoredProcedureNonQueryResponse>(true);
            _runStoredProcedureNonQueryResponseInstance = _runStoredProcedureNonQueryResponseInstanceFixture ?? this.Create<RunStoredProcedureNonQueryResponse>(false);
            CurrentInstance = _runStoredProcedureNonQueryResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="RunStoredProcedureNonQueryResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RunStoredProcedureNonQueryResponse_Is_Instance_Present_Test()
        {
            // Assert
            _runStoredProcedureNonQueryResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureNonQueryResponseInstance.ShouldNotBeNull();
            _runStoredProcedureNonQueryResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureNonQueryResponseInstance.ShouldBeAssignableTo<RunStoredProcedureNonQueryResponse>();
            _runStoredProcedureNonQueryResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureNonQueryResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunStoredProcedureNonQueryResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RunStoredProcedureNonQueryResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunStoredProcedureNonQueryResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runStoredProcedureNonQueryResponseInstanceType.ShouldNotBeNull();
            _runStoredProcedureNonQueryResponseInstance.ShouldNotBeNull();
            _runStoredProcedureNonQueryResponseInstanceFixture.ShouldNotBeNull();
            _runStoredProcedureNonQueryResponseInstance.ShouldBeAssignableTo<RunStoredProcedureNonQueryResponse>();
            _runStoredProcedureNonQueryResponseInstanceFixture.ShouldBeAssignableTo<RunStoredProcedureNonQueryResponse>();
        }

        #endregion

        #endregion

        #endregion
    }
}