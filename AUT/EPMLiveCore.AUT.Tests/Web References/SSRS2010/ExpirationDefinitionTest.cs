using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.SSRS2010;
using ExpirationDefinition = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.ExpirationDefinition" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ExpirationDefinitionTest : AbstractBaseSetupTypedTest<ExpirationDefinition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExpirationDefinition) Initializer

        private Type _expirationDefinitionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ExpirationDefinition _expirationDefinitionInstance;
        private ExpirationDefinition _expirationDefinitionInstanceFixture;

        #region General Initializer : Class (ExpirationDefinition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExpirationDefinition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _expirationDefinitionInstanceType = typeof(ExpirationDefinition);
            _expirationDefinitionInstanceFixture = Create(true);
            _expirationDefinitionInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ExpirationDefinition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ExpirationDefinition_Is_Instance_Present_Test()
        {
            // Assert
            _expirationDefinitionInstanceType.ShouldNotBeNull();
            _expirationDefinitionInstance.ShouldNotBeNull();
            _expirationDefinitionInstanceFixture.ShouldNotBeNull();
            _expirationDefinitionInstance.ShouldBeAssignableTo<ExpirationDefinition>();
            _expirationDefinitionInstanceFixture.ShouldBeAssignableTo<ExpirationDefinition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExpirationDefinition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ExpirationDefinition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ExpirationDefinition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _expirationDefinitionInstanceType.ShouldNotBeNull();
            _expirationDefinitionInstance.ShouldNotBeNull();
            _expirationDefinitionInstanceFixture.ShouldNotBeNull();
            _expirationDefinitionInstance.ShouldBeAssignableTo<ExpirationDefinition>();
            _expirationDefinitionInstanceFixture.ShouldBeAssignableTo<ExpirationDefinition>();
        }

        #endregion

        #endregion

        #endregion
    }
}