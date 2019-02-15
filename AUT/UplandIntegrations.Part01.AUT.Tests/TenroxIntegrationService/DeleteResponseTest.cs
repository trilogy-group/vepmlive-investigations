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
using UplandIntegrations.TenroxIntegrationService;
using DeleteResponse = UplandIntegrations.TenroxIntegrationService;

namespace UplandIntegrations.TenroxIntegrationService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxIntegrationService.DeleteResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxIntegrationService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeleteResponseTest : AbstractBaseSetupV3Test
    {
        public DeleteResponseTest() : base(typeof(DeleteResponse))
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

        #region General Initializer : Class (DeleteResponse) Initializer

        private Type _deleteResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private DeleteResponse _deleteResponseInstance;
        private DeleteResponse _deleteResponseInstanceFixture;

        #region General Initializer : Class (DeleteResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeleteResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deleteResponseInstanceType = typeof(DeleteResponse);
            _deleteResponseInstanceFixture = this.Create<DeleteResponse>(true);
            _deleteResponseInstance = _deleteResponseInstanceFixture ?? this.Create<DeleteResponse>(false);
            CurrentInstance = _deleteResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DeleteResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DeleteResponse_Is_Instance_Present_Test()
        {
            // Assert
            _deleteResponseInstanceType.ShouldNotBeNull();
            _deleteResponseInstance.ShouldNotBeNull();
            _deleteResponseInstanceFixture.ShouldNotBeNull();
            _deleteResponseInstance.ShouldBeAssignableTo<DeleteResponse>();
            _deleteResponseInstanceFixture.ShouldBeAssignableTo<DeleteResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeleteResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DeleteResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeleteResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deleteResponseInstanceType.ShouldNotBeNull();
            _deleteResponseInstance.ShouldNotBeNull();
            _deleteResponseInstanceFixture.ShouldNotBeNull();
            _deleteResponseInstance.ShouldBeAssignableTo<DeleteResponse>();
            _deleteResponseInstanceFixture.ShouldBeAssignableTo<DeleteResponse>();
        }

        #endregion

        #endregion

        #endregion
    }
}