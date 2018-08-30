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
using EPMLiveCore.SSRS2006;
using RecurrencePattern = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.RecurrencePattern" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RecurrencePatternTest : AbstractBaseSetupTypedTest<RecurrencePattern>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RecurrencePattern) Initializer

        private Type _recurrencePatternInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RecurrencePattern _recurrencePatternInstance;
        private RecurrencePattern _recurrencePatternInstanceFixture;

        #region General Initializer : Class (RecurrencePattern) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RecurrencePattern" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _recurrencePatternInstanceType = typeof(RecurrencePattern);
            _recurrencePatternInstanceFixture = Create(true);
            _recurrencePatternInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="RecurrencePattern" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RecurrencePattern_Is_Instance_Present_Test()
        {
            // Assert
            _recurrencePatternInstanceType.ShouldNotBeNull();
            _recurrencePatternInstance.ShouldNotBeNull();
            _recurrencePatternInstanceFixture.ShouldNotBeNull();
            _recurrencePatternInstance.ShouldBeAssignableTo<RecurrencePattern>();
            _recurrencePatternInstanceFixture.ShouldBeAssignableTo<RecurrencePattern>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RecurrencePattern) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RecurrencePattern_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RecurrencePattern instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _recurrencePatternInstanceType.ShouldNotBeNull();
            _recurrencePatternInstance.ShouldNotBeNull();
            _recurrencePatternInstanceFixture.ShouldNotBeNull();
            _recurrencePatternInstance.ShouldBeAssignableTo<RecurrencePattern>();
            _recurrencePatternInstanceFixture.ShouldBeAssignableTo<RecurrencePattern>();
        }

        #endregion

        #endregion

        #endregion
    }
}