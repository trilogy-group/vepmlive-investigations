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
using ScheduleDefinitionOrReference = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.ScheduleDefinitionOrReference" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ScheduleDefinitionOrReferenceTest : AbstractBaseSetupTypedTest<ScheduleDefinitionOrReference>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ScheduleDefinitionOrReference) Initializer

        private Type _scheduleDefinitionOrReferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ScheduleDefinitionOrReference _scheduleDefinitionOrReferenceInstance;
        private ScheduleDefinitionOrReference _scheduleDefinitionOrReferenceInstanceFixture;

        #region General Initializer : Class (ScheduleDefinitionOrReference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ScheduleDefinitionOrReference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _scheduleDefinitionOrReferenceInstanceType = typeof(ScheduleDefinitionOrReference);
            _scheduleDefinitionOrReferenceInstanceFixture = Create(true);
            _scheduleDefinitionOrReferenceInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ScheduleDefinitionOrReference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ScheduleDefinitionOrReference_Is_Instance_Present_Test()
        {
            // Assert
            _scheduleDefinitionOrReferenceInstanceType.ShouldNotBeNull();
            _scheduleDefinitionOrReferenceInstance.ShouldNotBeNull();
            _scheduleDefinitionOrReferenceInstanceFixture.ShouldNotBeNull();
            _scheduleDefinitionOrReferenceInstance.ShouldBeAssignableTo<ScheduleDefinitionOrReference>();
            _scheduleDefinitionOrReferenceInstanceFixture.ShouldBeAssignableTo<ScheduleDefinitionOrReference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ScheduleDefinitionOrReference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ScheduleDefinitionOrReference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ScheduleDefinitionOrReference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _scheduleDefinitionOrReferenceInstanceType.ShouldNotBeNull();
            _scheduleDefinitionOrReferenceInstance.ShouldNotBeNull();
            _scheduleDefinitionOrReferenceInstanceFixture.ShouldNotBeNull();
            _scheduleDefinitionOrReferenceInstance.ShouldBeAssignableTo<ScheduleDefinitionOrReference>();
            _scheduleDefinitionOrReferenceInstanceFixture.ShouldBeAssignableTo<ScheduleDefinitionOrReference>();
        }

        #endregion

        #endregion

        #endregion
    }
}