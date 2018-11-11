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
using UplandIntegrations.TenroxTaskService;
using BulkDeleteSerializedResponse = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.BulkDeleteSerializedResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class BulkDeleteSerializedResponseTest : AbstractBaseSetupV3Test
    {
        public BulkDeleteSerializedResponseTest() : base(typeof(BulkDeleteSerializedResponse))
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

        #region General Initializer : Class (BulkDeleteSerializedResponse) Initializer

        private Type _bulkDeleteSerializedResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private BulkDeleteSerializedResponse _bulkDeleteSerializedResponseInstance;
        private BulkDeleteSerializedResponse _bulkDeleteSerializedResponseInstanceFixture;

        #region General Initializer : Class (BulkDeleteSerializedResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BulkDeleteSerializedResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _bulkDeleteSerializedResponseInstanceType = typeof(BulkDeleteSerializedResponse);
            _bulkDeleteSerializedResponseInstanceFixture = this.Create<BulkDeleteSerializedResponse>(true);
            _bulkDeleteSerializedResponseInstance = _bulkDeleteSerializedResponseInstanceFixture ?? this.Create<BulkDeleteSerializedResponse>(false);
            CurrentInstance = _bulkDeleteSerializedResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="BulkDeleteSerializedResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_BulkDeleteSerializedResponse_Is_Instance_Present_Test()
        {
            // Assert
            _bulkDeleteSerializedResponseInstanceType.ShouldNotBeNull();
            _bulkDeleteSerializedResponseInstance.ShouldNotBeNull();
            _bulkDeleteSerializedResponseInstanceFixture.ShouldNotBeNull();
            _bulkDeleteSerializedResponseInstance.ShouldBeAssignableTo<BulkDeleteSerializedResponse>();
            _bulkDeleteSerializedResponseInstanceFixture.ShouldBeAssignableTo<BulkDeleteSerializedResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BulkDeleteSerializedResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BulkDeleteSerializedResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BulkDeleteSerializedResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _bulkDeleteSerializedResponseInstanceType.ShouldNotBeNull();
            _bulkDeleteSerializedResponseInstance.ShouldNotBeNull();
            _bulkDeleteSerializedResponseInstanceFixture.ShouldNotBeNull();
            _bulkDeleteSerializedResponseInstance.ShouldBeAssignableTo<BulkDeleteSerializedResponse>();
            _bulkDeleteSerializedResponseInstanceFixture.ShouldBeAssignableTo<BulkDeleteSerializedResponse>();
        }

        #endregion

        #endregion

        #endregion
    }
}