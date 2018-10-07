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
using System.Runtime.Serialization;
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
using UplandIntegrations.TenroxAuthService;
using LogonFaultContract = UplandIntegrations.TenroxAuthService;

namespace UplandIntegrations.TenroxAuthService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAuthService.LogonFaultContract" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAuthService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LogonFaultContractTest : AbstractBaseSetupV3Test
    {
        public LogonFaultContractTest() : base(typeof(LogonFaultContract))
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

        #region General Initializer : Class (LogonFaultContract) Initializer

        private Type _logonFaultContractInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private LogonFaultContract _logonFaultContractInstance;
        private LogonFaultContract _logonFaultContractInstanceFixture;

        #region General Initializer : Class (LogonFaultContract) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LogonFaultContract" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _logonFaultContractInstanceType = typeof(LogonFaultContract);
            _logonFaultContractInstanceFixture = this.Create<LogonFaultContract>(true);
            _logonFaultContractInstance = _logonFaultContractInstanceFixture ?? this.Create<LogonFaultContract>(false);
            CurrentInstance = _logonFaultContractInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="LogonFaultContract" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_LogonFaultContract_Is_Instance_Present_Test()
        {
            // Assert
            _logonFaultContractInstanceType.ShouldNotBeNull();
            _logonFaultContractInstance.ShouldNotBeNull();
            _logonFaultContractInstanceFixture.ShouldNotBeNull();
            _logonFaultContractInstance.ShouldBeAssignableTo<LogonFaultContract>();
            _logonFaultContractInstanceFixture.ShouldBeAssignableTo<LogonFaultContract>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LogonFaultContract) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_LogonFaultContract_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LogonFaultContract instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _logonFaultContractInstanceType.ShouldNotBeNull();
            _logonFaultContractInstance.ShouldNotBeNull();
            _logonFaultContractInstanceFixture.ShouldNotBeNull();
            _logonFaultContractInstance.ShouldBeAssignableTo<LogonFaultContract>();
            _logonFaultContractInstanceFixture.ShouldBeAssignableTo<LogonFaultContract>();
        }

        #endregion

        #endregion

        #endregion
    }
}