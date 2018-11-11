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
using DeleteSerializedResponse = UplandIntegrations.TenroxIntegrationService;

namespace UplandIntegrations.TenroxIntegrationService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxIntegrationService.DeleteSerializedResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxIntegrationService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeleteSerializedResponseTest : AbstractBaseSetupV3Test
    {
        public DeleteSerializedResponseTest() : base(typeof(DeleteSerializedResponse))
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

        #region General Initializer : Class (DeleteSerializedResponse) Initializer

        private Type _deleteSerializedResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private DeleteSerializedResponse _deleteSerializedResponseInstance;
        private DeleteSerializedResponse _deleteSerializedResponseInstanceFixture;

        #region General Initializer : Class (DeleteSerializedResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeleteSerializedResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deleteSerializedResponseInstanceType = typeof(DeleteSerializedResponse);
            _deleteSerializedResponseInstanceFixture = this.Create<DeleteSerializedResponse>(true);
            _deleteSerializedResponseInstance = _deleteSerializedResponseInstanceFixture ?? this.Create<DeleteSerializedResponse>(false);
            CurrentInstance = _deleteSerializedResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DeleteSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DeleteSerializedResponse_Is_Instance_Present_Test()
        {
            // Assert
            _deleteSerializedResponseInstanceType.ShouldNotBeNull();
            _deleteSerializedResponseInstance.ShouldNotBeNull();
            _deleteSerializedResponseInstanceFixture.ShouldNotBeNull();
            _deleteSerializedResponseInstance.ShouldBeAssignableTo<DeleteSerializedResponse>();
            _deleteSerializedResponseInstanceFixture.ShouldBeAssignableTo<DeleteSerializedResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeleteSerializedResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DeleteSerializedResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeleteSerializedResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deleteSerializedResponseInstanceType.ShouldNotBeNull();
            _deleteSerializedResponseInstance.ShouldNotBeNull();
            _deleteSerializedResponseInstanceFixture.ShouldNotBeNull();
            _deleteSerializedResponseInstance.ShouldBeAssignableTo<DeleteSerializedResponse>();
            _deleteSerializedResponseInstanceFixture.ShouldBeAssignableTo<DeleteSerializedResponse>();
        }

        #endregion

        #endregion

        #endregion
    }
}