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
using UplandIntegrations.IntegrationAPI;
using AddUpdateItemCompletedEventArgs = UplandIntegrations.IntegrationAPI;

namespace UplandIntegrations.IntegrationAPI
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.IntegrationAPI.AddUpdateItemCompletedEventArgs" />)
    ///     and namespace <see cref="UplandIntegrations.IntegrationAPI"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AddUpdateItemCompletedEventArgsTest : AbstractBaseSetupV3Test
    {
        public AddUpdateItemCompletedEventArgsTest() : base(typeof(AddUpdateItemCompletedEventArgs))
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

        #region General Initializer : Class (AddUpdateItemCompletedEventArgs) Initializer

        #region Properties

        private const string PropertyResult = "Result";

        #endregion

        #region Fields

        private const string Fieldresults = "results";

        #endregion

        private Type _addUpdateItemCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private AddUpdateItemCompletedEventArgs _addUpdateItemCompletedEventArgsInstance;
        private AddUpdateItemCompletedEventArgs _addUpdateItemCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (AddUpdateItemCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AddUpdateItemCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addUpdateItemCompletedEventArgsInstanceType = typeof(AddUpdateItemCompletedEventArgs);
            _addUpdateItemCompletedEventArgsInstanceFixture = this.Create<AddUpdateItemCompletedEventArgs>(true);
            _addUpdateItemCompletedEventArgsInstance = _addUpdateItemCompletedEventArgsInstanceFixture ?? this.Create<AddUpdateItemCompletedEventArgs>(false);
            CurrentInstance = _addUpdateItemCompletedEventArgsInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}