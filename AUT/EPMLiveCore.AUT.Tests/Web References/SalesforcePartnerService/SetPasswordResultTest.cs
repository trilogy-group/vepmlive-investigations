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
using EPMLiveCore.SalesforcePartnerService;
using SetPasswordResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.SetPasswordResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SetPasswordResultTest : AbstractBaseSetupTypedTest<SetPasswordResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SetPasswordResult) Initializer

        private Type _setPasswordResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SetPasswordResult _setPasswordResultInstance;
        private SetPasswordResult _setPasswordResultInstanceFixture;

        #region General Initializer : Class (SetPasswordResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SetPasswordResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _setPasswordResultInstanceType = typeof(SetPasswordResult);
            _setPasswordResultInstanceFixture = Create(true);
            _setPasswordResultInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="SetPasswordResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SetPasswordResult_Is_Instance_Present_Test()
        {
            // Assert
            _setPasswordResultInstanceType.ShouldNotBeNull();
            _setPasswordResultInstance.ShouldNotBeNull();
            _setPasswordResultInstanceFixture.ShouldNotBeNull();
            _setPasswordResultInstance.ShouldBeAssignableTo<SetPasswordResult>();
            _setPasswordResultInstanceFixture.ShouldBeAssignableTo<SetPasswordResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SetPasswordResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SetPasswordResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SetPasswordResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _setPasswordResultInstanceType.ShouldNotBeNull();
            _setPasswordResultInstance.ShouldNotBeNull();
            _setPasswordResultInstanceFixture.ShouldNotBeNull();
            _setPasswordResultInstance.ShouldBeAssignableTo<SetPasswordResult>();
            _setPasswordResultInstanceFixture.ShouldBeAssignableTo<SetPasswordResult>();
        }

        #endregion

        #endregion

        #endregion
    }
}