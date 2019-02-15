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
using EPMLiveWorkPlanner;
using ResourceInformation = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.ResourceInformation" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ResourceInformationTest : AbstractBaseSetupV3Test
    {
        public ResourceInformationTest() : base(typeof(ResourceInformation))
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

        #region General Initializer : Class (ResourceInformation) Initializer

        private Type _resourceInformationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ResourceInformation _resourceInformationInstance;
        private ResourceInformation _resourceInformationInstanceFixture;

        #region General Initializer : Class (ResourceInformation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceInformation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceInformationInstanceType = typeof(ResourceInformation);
            _resourceInformationInstanceFixture = this.Create<ResourceInformation>(true);
            _resourceInformationInstance = _resourceInformationInstanceFixture ?? this.Create<ResourceInformation>(false);
            CurrentInstance = _resourceInformationInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ResourceInformation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourceInformation_Is_Instance_Present_Test()
        {
            // Assert
            _resourceInformationInstanceType.ShouldNotBeNull();
            _resourceInformationInstance.ShouldNotBeNull();
            _resourceInformationInstanceFixture.ShouldNotBeNull();
            _resourceInformationInstance.ShouldBeAssignableTo<ResourceInformation>();
            _resourceInformationInstanceFixture.ShouldBeAssignableTo<ResourceInformation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceInformation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourceInformation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourceInformation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourceInformationInstanceType.ShouldNotBeNull();
            _resourceInformationInstance.ShouldNotBeNull();
            _resourceInformationInstanceFixture.ShouldNotBeNull();
            _resourceInformationInstance.ShouldBeAssignableTo<ResourceInformation>();
            _resourceInformationInstanceFixture.ShouldBeAssignableTo<ResourceInformation>();
        }

        #endregion

        #endregion

        #endregion
    }
}