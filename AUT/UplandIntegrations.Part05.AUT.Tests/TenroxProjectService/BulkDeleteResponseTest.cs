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
using UplandIntegrations.TenroxProjectService;
using BulkDeleteResponse = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.BulkDeleteResponse" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class BulkDeleteResponseTest : AbstractBaseSetupV3Test
    {
        public BulkDeleteResponseTest() : base(typeof(BulkDeleteResponse))
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

        #region General Initializer : Class (BulkDeleteResponse) Initializer

        private Type _bulkDeleteResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private BulkDeleteResponse _bulkDeleteResponseInstance;
        private BulkDeleteResponse _bulkDeleteResponseInstanceFixture;

        #region General Initializer : Class (BulkDeleteResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BulkDeleteResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _bulkDeleteResponseInstanceType = typeof(BulkDeleteResponse);
            _bulkDeleteResponseInstanceFixture = this.Create<BulkDeleteResponse>(true);
            _bulkDeleteResponseInstance = _bulkDeleteResponseInstanceFixture ?? this.Create<BulkDeleteResponse>(false);
            CurrentInstance = _bulkDeleteResponseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="BulkDeleteResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_BulkDeleteResponse_Is_Instance_Present_Test()
        {
            // Assert
            _bulkDeleteResponseInstanceType.ShouldNotBeNull();
            _bulkDeleteResponseInstance.ShouldNotBeNull();
            _bulkDeleteResponseInstanceFixture.ShouldNotBeNull();
            _bulkDeleteResponseInstance.ShouldBeAssignableTo<BulkDeleteResponse>();
            _bulkDeleteResponseInstanceFixture.ShouldBeAssignableTo<BulkDeleteResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BulkDeleteResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BulkDeleteResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BulkDeleteResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _bulkDeleteResponseInstanceType.ShouldNotBeNull();
            _bulkDeleteResponseInstance.ShouldNotBeNull();
            _bulkDeleteResponseInstanceFixture.ShouldNotBeNull();
            _bulkDeleteResponseInstance.ShouldBeAssignableTo<BulkDeleteResponse>();
            _bulkDeleteResponseInstanceFixture.ShouldBeAssignableTo<BulkDeleteResponse>();
        }

        #endregion

        #endregion

        #endregion
    }
}